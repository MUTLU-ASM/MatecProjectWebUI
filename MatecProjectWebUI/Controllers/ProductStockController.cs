using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MatecProjectWebUI.Controllers
{
    public class ProductStockController : Controller
    {
        IProductStockService _productStockService;

        public ProductStockController(IProductStockService productStockService)
        {
            _productStockService = productStockService;
        }

        public IActionResult Index()
        {
            var values = _productStockService.TGetListInclude();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
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
            var value = _productStockService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(ProductStock productStock)
        {
            _productStockService.TUpdate(productStock);
            return RedirectToAction("Index");
        }
    }
}
