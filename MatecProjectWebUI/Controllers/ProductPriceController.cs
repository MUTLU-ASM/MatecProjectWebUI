using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MatecProjectWebUI.Controllers
{
    public class ProductPriceController : Controller
    {
        IProductPriceService _productPriceService;

        public ProductPriceController(IProductPriceService productPriceService)
        {
            _productPriceService = productPriceService;
        }

        public IActionResult Index()
        {
            var values = _productPriceService.TGetListInclude();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
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
    }
}
