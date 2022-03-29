using BusinessLayer.Services.Interface;
using DataAccessLayer.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactServices;
        private readonly ICityService _cityService;
        public ContactController(IContactService contactService,ICityService cityService)
        {
            _cityService = cityService;
            _contactServices = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetByContactInfo(int personId)
        {
            var result = await _contactServices.GetByIdContactInfo(personId);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var valueCity = await _cityService.CityList();
            ContactDTO contactDTO = new ContactDTO
            {
                PersonId = id,
                Cities = valueCity
             
            };
            return View(contactDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactDTO contact)
        {
            await _contactServices.Add(contact);
            return RedirectToAction("GetList");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _contactServices.GetByIdContact(id);
            var cityvalue = await _cityService.CityList();
            value.Cities = cityvalue;
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ContactDTO contact)
        {
            await _contactServices.Update(contact);
            var result = await _contactServices.GetByIdContactInfo(contact.PersonId);
            return View("GetByContactInfo", result);
        }
    }
}
