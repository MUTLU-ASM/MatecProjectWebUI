using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatecProjectWebUI.Controllers
{
    public class ProductStockController : Controller
    {
        IProductStockService _productStockService;
        IProductService _productService;
        IUnitTypeService _unitTypeService;

        public ProductStockController(IProductStockService productStockService, IProductService productService, IUnitTypeService unitTypeService)
        {
            _productStockService = productStockService;
            _productService = productService;
            _unitTypeService = unitTypeService;
        }

        public IActionResult Index()
        {
            var values = _productStockService.TGetListInclude();
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
        public IActionResult Create(ProductStock productStock)
        {
            _productStockService.TAdd(productStock);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productStockService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<SelectListItem> productList = GetProductList();
            List<SelectListItem> unitTypeList = GetUnitTypeList();
            ViewBag.productList = productList;
            ViewBag.unitTypeList = unitTypeList;
            var value = _productStockService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(ProductStock productStock)
        {
            _productStockService.TUpdate(productStock);
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
