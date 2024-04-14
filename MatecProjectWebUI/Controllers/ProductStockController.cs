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
            DataSelectLists();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductStock productStock)
        {
            if (ModelState.IsValid)
            {
                _productStockService.TAdd(productStock);
                return RedirectToAction("Index");
            }
            DataSelectLists();
            return View();
        }

        public IActionResult Delete(int id)
        {
            _productStockService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            DataSelectLists();
            var value = _productStockService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(ProductStock productStock)
        {
            if (ModelState.IsValid)
            {
                _productStockService.TUpdate(productStock);
                return RedirectToAction("Index");
            }
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
