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
        public ContactController(IContactService contactService)
        {
            _contactServices = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactDTO contact)
        {
            await _contactServices.Add(contact);
            return RedirectToAction("GetList");
        }
    }
}
