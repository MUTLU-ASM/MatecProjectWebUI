using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MatecProjectWebUI.Controllers
{
    public class UnitTypeController : Controller
    {
        IUnitTypeService _unitTypeService;

        public UnitTypeController(IUnitTypeService unitTypeService)
        {
            _unitTypeService = unitTypeService;
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
            if (ModelState.IsValid)
            {
                _unitTypeService.TAdd(unitType);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _unitTypeService.TDelete(id);
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
            if (ModelState.IsValid)
            {
                _unitTypeService.TUpdate(unitType);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
