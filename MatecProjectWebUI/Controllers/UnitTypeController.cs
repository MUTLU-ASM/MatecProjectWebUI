using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NToastNotify;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MatecProjectWebUI.Controllers
{
    public class UnitTypeController : Controller
    {
        IUnitTypeService _unitTypeService;
        IToastNotification _toastNotification;

        public UnitTypeController(IUnitTypeService unitTypeService, IToastNotification toastNotification)
        {
            _unitTypeService = unitTypeService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            var values = _unitTypeService.TGetAllList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UnitType unitType)
        {
            if (!ModelState.IsValid)
            {
                _unitTypeService.TAdd(unitType);
                _toastNotification.AddSuccessToastMessage(message: $"{unitType.Name} Başarılı şekilde eklenmiştir.");
                return RedirectToAction("Index");
            }
            _toastNotification.AddErrorToastMessage(message: $"Başarısız işlem");
            return View();
        }

        public IActionResult Delete(int id)
        {
            var value = _unitTypeService.TGetById(id);
            _unitTypeService.TDelete(id);
            _toastNotification.AddWarningToastMessage(message: $"{value.Name} Başarılı şekilde silinmiştir.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _unitTypeService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(UnitType unitType)
        {
            if (!ModelState.IsValid)
            {
                _unitTypeService.TUpdate(unitType);
                _toastNotification.AddSuccessToastMessage(message: $"{unitType.Name} Başarılı şekilde güncellenmiştir.");
                return RedirectToAction("Index");
            }
            _toastNotification.AddSuccessToastMessage(message: $"{unitType.Name} Başarısız güncelleme.");
            return View();
        }
    }
}
