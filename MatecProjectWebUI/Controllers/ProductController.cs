using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatecProjectWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICompanyService _companyService;

        public ProductController(IProductService productService, ICompanyService companyService)
        {
            _productService = productService;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetListInclude();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> companyList = GetCompanyList();
            ViewBag.companyList = companyList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Status = 1;
            _productService.TAdd(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.statusList = new List<SelectListItem>
            {
                  new SelectListItem { Text = "Pasif", Value = "0" },
                  new SelectListItem { Text = "Aktif", Value = "1" }
             };
            List<SelectListItem> companyList = GetCompanyList();
            ViewBag.companyList = companyList;
            var value = _productService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("Index");
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
    }
}
