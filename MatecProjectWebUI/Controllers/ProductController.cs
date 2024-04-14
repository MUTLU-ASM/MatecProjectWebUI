using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MatecProjectWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICompanyService _companyService;
        IToastNotification _toastNotification;

        public ProductController(IProductService productService, ICompanyService companyService, IToastNotification toastNotification)
        {
            _productService = productService;
            _companyService = companyService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetListInclude();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            DataSelectLists();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddSuccessToastMessage(message: $"{product.Name} Başarılı şekilde eklenmiştir.");
                product.Status = 1;
                _productService.TAdd(product);
                return RedirectToAction("Index");
            }
            _toastNotification.AddErrorToastMessage(message: $"Başarısız işlem");
            DataSelectLists();
            return View();

        }

        public IActionResult Delete(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(id);
            _toastNotification.AddSuccessToastMessage(message: $"{value.Name} Başarılı şekilde silinmiştir.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            StatusList();
            DataSelectLists();
            var value = _productService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddSuccessToastMessage(message: $"{product.Name} Başarılı şekilde güncellenmiştir.");
                _productService.TUpdate(product);
                return RedirectToAction("Index");
            }
            _toastNotification.AddSuccessToastMessage(message: $"{product.Name} Başarısız güncelleme.");
            StatusList();
            DataSelectLists();
            return View();
        }

        private List<SelectListItem> GetCompanyList()
        {
            return (from x in _companyService.TGetAllList()
                    select new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.CompanyId.ToString()
                    }).ToList();
        }
        private void DataSelectLists()
        {
            ViewBag.companyList = GetCompanyList();
        }
        private void StatusList()
        {
            ViewBag.statusList = new List<SelectListItem>
             {
                   new SelectListItem { Text = "Pasif", Value = "0" },
                   new SelectListItem { Text = "Aktif", Value = "1" }
             };
        }
    }
}
