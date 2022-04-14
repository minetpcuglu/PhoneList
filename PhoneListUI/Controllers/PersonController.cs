using BusinessLayer.Services.Interface;
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListUI.Controllers
{
    public class PersonController : Controller
    {

        private readonly IPersonService _personServices;
        public PersonController(IPersonService personService)
        {
            _personServices = personService;
        }

        public async Task<IActionResult> GetList()
        {
            var result = await _personServices.GetAll();
            
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonDTO person)
        {
          
            await _personServices.Add(person);
            return RedirectToAction("GetList");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var result = await _personServices.DeleteAsync(id);
                if (result)
                {
                    return Json(new ToastViewModel
                    {
                        Message = "silindi.",
                        Success = true
                    });
                }
                else
                {
                    return Json(new ToastViewModel
                    {
                        Message = "İşlem Başarısız.",
                        Success = false
                    });
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult>  Update(int id)
        {
            var value = await _personServices.GetById(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PersonDTO person)
        {
            await _personServices.Update(person);
            return RedirectToAction("GetList");
        }

        //konuma göre rapor getirme
        [HttpGet]
        public async Task<IActionResult> PersonLocationReport()
        {
            var person = await _personServices.GetPersonLocationReport();
            return View(person);
        }

    }
}
