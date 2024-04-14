using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NToastNotify;

namespace MatecProjectWebUI.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;
        IToastNotification _toastNotification;

        public CompanyController(ICompanyService companyService, IToastNotification toastNotification)
        {
            _companyService = companyService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            var values = _companyService.TGetAllList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                _companyService.TAdd(company);
                _toastNotification.AddSuccessToastMessage(message: $"{company.Name} Başarılı şekilde eklenmiştir.");
                return RedirectToAction("Index");
            }
            _toastNotification.AddErrorToastMessage(message: $"Başarısız işlem");
            return View();
        }

        public IActionResult Delete(int id)
        {
            var value = _companyService.TGetById(id);
            _companyService.TDelete(id);
            _toastNotification.AddWarningToastMessage(message: $"{value.Name} Başarılı şekilde silinmiştir.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var value = _companyService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddSuccessToastMessage(message: $"{company.Name} Başarılı şekilde güncellenmiştir.");
                _companyService.TUpdate(company);
                return RedirectToAction("Index");
            }
            _toastNotification.AddSuccessToastMessage(message: $"{company.Name} Başarısız güncelleme.");
            return View();
        }
    }
}
