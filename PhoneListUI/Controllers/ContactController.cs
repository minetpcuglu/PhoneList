
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                var responseMessage = await httpClient.GetAsync("https://localhost:44337/api/Contact/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<ContactDTO>>(jsonEmployee);
                    return View(value);
                }
                return RedirectToAction("GetList", "Person");

            }

        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync("https://localhost:44337/api/City/GetList");
                var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
                var values = JsonConvert.DeserializeObject<List<CityDTO>>(jsonString); //listelerken
                ContactDTO contactDTO = new ContactDTO
                {
                    PersonId = id,
                    Cities = values,
                    

                };
               
                return View(contactDTO);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactDTO contact)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44337/api/Contact/Create/", content);
            using (var httpClient = new HttpClient())
            {
                var responseMessage2 = await httpClient.GetAsync("https://localhost:44337/api/Contact/" + contact.PersonId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonEmployee = await responseMessage2.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<ContactDTO>>(jsonEmployee);

                    return View("GetByContactInfo", value);
                }


            }
            return View(contact);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync("https://localhost:44337/api/Contact/" + id);
                var responseMessage2 = await httpClient.GetAsync("https://localhost:44337/api/City/GetList");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContact = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<ContactDTO>>(jsonContact);
                    //return View(value);


                    var jsonString = await responseMessage2.Content.ReadAsStringAsync(); //asenkron olarak karsıla
                    var values = JsonConvert.DeserializeObject<List<CityDTO>>(jsonString); //listelerken

                    //var mine = value.Where(x => x.Id == id).Select(x => x.CityName);
                    //var elif = values.Select(y => y.CityName);
                     //result.Cities = city;?? bunu nasıl yapablirim
                    //var mine=  value.Where(x => x.Id == id).Select(y => y.Cities).FirstOrDefault();
                    //mine = values;
                    //return View(mine);
                   
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactDTO contact)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44337/api/Contact/Update/", content);
            using (var httpClient = new HttpClient())
            {
                var responseMessage2 = await httpClient.GetAsync("https://localhost:44337/api/Contact/" + contact.PersonId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContact = await responseMessage2.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<ContactDTO>>(jsonContact);

                    return View("GetByContactInfo", value);
                }


            }
            return View(contact);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                using (var httpClient = new HttpClient())
                {
                    var responseMessage = await httpClient.DeleteAsync("https://localhost:44337/api/Contact/" + id);
                    if (responseMessage.IsSuccessStatusCode)
                    {

                        return RedirectToAction("GetList", "Person");
                    }
                }
            }
            return View();
          
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

