using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using NToastNotify;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MatecProjectWebUI.Controllers
{
    public class ProductPriceController : Controller
    {
        IProductPriceService _productPriceService;
        IUnitTypeService _unitTypeService;
        IProductService _productService;
        IToastNotification _toastNotification;

        public ProductPriceController(IProductPriceService productPriceService, IUnitTypeService unitTypeService, IProductService productService, IToastNotification toastNotification)
        {
            _productPriceService = productPriceService;
            _unitTypeService = unitTypeService;
            _productService = productService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            var values = _productPriceService.TGetListInclude();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            DataSelectLists();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductPrice productPrice)
        {
            if (!ModelState.IsValid)
            {
                productPrice.LastUpdateDate = null;
                _productPriceService.TAdd(productPrice);
                _toastNotification.AddSuccessToastMessage(message: $"Başarılı şekilde eklenmiştir.");
                return RedirectToAction("Index");
            }
            _toastNotification.AddErrorToastMessage(message: $"Başarısız işlem");
            DataSelectLists();
            return View();
        }

        public IActionResult Delete(int id)
        {
            _productPriceService.TDelete(id);
            _toastNotification.AddWarningToastMessage(message: $"Başarılı şekilde silinmiştir.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            DataSelectLists();
            var value = _productPriceService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(ProductPrice productPrice)
        {
            if (!ModelState.IsValid)
            {
                productPrice.LastUpdateDate = DateTime.Now;
                _productPriceService.TUpdate(productPrice);
                _toastNotification.AddSuccessToastMessage(message: $"Başarılı şekilde güncellenmiştir.");
                return RedirectToAction("Index");
            }
            _toastNotification.AddSuccessToastMessage(message: $"Başarısız güncelleme.");
            DataSelectLists();
            return View();
        }

        private List<SelectListItem> GetProductList()
        {
            return (from x in _productService.TGetAllList()
                    select new SelectListItem
                    {
                        Text = x.Code,
                        Value = x.ProductId.ToString()
                    }).ToList();
        }

        private List<SelectListItem> GetUnitTypeList()
        {
            return (from x in _unitTypeService.TGetAllList()
                    select new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.UnitTypeId.ToString()
                    }).ToList();
        }
        private void DataSelectLists()
        {
            ViewBag.productList = GetProductList();
            ViewBag.unitTypeList = GetUnitTypeList();
        }
    }
}
