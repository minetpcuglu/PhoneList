
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneListUI.Controllers
{
    public class ContactController : Controller
    {
        //private readonly IContactService _contactServices;
        //private readonly ICityService _cityService;
        //public ContactController(IContactService contactService,ICityService cityService)
        //{
        //    _cityService = cityService;
        //    _contactServices = contactService;
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetByContactInfo(int id)
        {
            //var result = await _contactServices.GetByIdContactInfo(id);
            //return View(result);
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync("https://localhost:44337/api/Contact/GetByIdContactInfo/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<ContactDTO>(jsonEmployee);
                    return View(value);
                }
                return RedirectToAction("GetList","Person");

            }

        }

        //[HttpGet]
        //public async Task<IActionResult> Update(int id)
        //{
        //    var value = await _contactServices.GetByIdContact(id);
        //    var cityvalue = await _cityService.CityList();
        //    value.Cities = cityvalue;
        //    return View(value);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(ContactDTO contact)
        //{
        //    await _contactServices.Update(contact);
        //    var result = await _contactServices.GetByIdContactInfo(contact.PersonId);
        //    return View("GetByContactInfo", result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Create(int id)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        var responseMessage = await httpClient.GetAsync("https://localhost:44337/api/City/GetList");
        //        var valueCity = await _cityService.CityList();
        //    ContactDTO contactDTO = new ContactDTO
        //    {
        //        PersonId = id,
        //        Cities = valueCity

        //    };
        //    return View(contactDTO);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(ContactDTO contact)
        //{
        //    await _contactServices.Add(contact);

        //    return RedirectToAction("GetList","Person");
        //}


        //[HttpGet]
        //public async Task<IActionResult> Update(int id)
        //{
        //    var value = await _contactServices.GetByIdContact(id);
        //    var cityvalue = await _cityService.CityList();
        //    value.Cities = cityvalue;
        //    return View(value);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(ContactDTO contact)
        //{
        //    await _contactServices.Update(contact);
        //    var result = await _contactServices.GetByIdContactInfo(contact.PersonId);
        //    return View("GetByContactInfo", result);
        //}


        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id != 0)
        //    {
        //        var result = await _contactServices.DeleteAsync(id);
        //    }
        //    return RedirectToAction("GetList","Person");
        //}
    }
}
