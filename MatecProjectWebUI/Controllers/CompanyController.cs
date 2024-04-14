﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MatecProjectWebUI.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
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
            if (ModelState.IsValid)
            {
                _companyService.TAdd(company);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _companyService.TDelete(id);
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
            if (ModelState.IsValid)
            {
                _companyService.TUpdate(company);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
