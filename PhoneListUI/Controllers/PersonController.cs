using BusinessLayer.Services.Interface;
using DataAccessLayer.Models.DTOs;
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
        

    }
}
