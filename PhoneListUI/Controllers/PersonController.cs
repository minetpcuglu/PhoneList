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
       
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
               await _personServices.Delete(id);
                return RedirectToAction("GetList");
            }
            return BadRequest();
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



    }
}
