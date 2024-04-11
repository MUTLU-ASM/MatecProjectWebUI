using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatecProjectWebUI.Controllers
{
    public class ProductPriceController : Controller
    {
        IProductPriceService _productPriceService;
        IUnitTypeService _unitTypeService;
        IProductService _productService;

        public ProductPriceController(IProductPriceService productPriceService, IUnitTypeService unitTypeService, IProductService productService)
        {
            _productPriceService = productPriceService;
            _unitTypeService = unitTypeService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values = _productPriceService.TGetListInclude();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> productList = GetProductList();
            List<SelectListItem> unitTypeList = GetUnitTypeList();
            ViewBag.productList = productList;
            ViewBag.unitTypeList = unitTypeList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductPrice productPrice)
        {
            productPrice.LastUpdateDate = null;
            _productPriceService.TAdd(productPrice);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productPriceService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<SelectListItem> productList = GetProductList();
            List<SelectListItem> unitTypeList = GetUnitTypeList();
            ViewBag.productList = productList;
            ViewBag.unitTypeList = unitTypeList;
            var value = _productPriceService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(ProductPrice productPrice)
        {
            productPrice.LastUpdateDate = DateTime.Now;
            _productPriceService.TUpdate(productPrice);
            return RedirectToAction("Index");
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
    }
}
