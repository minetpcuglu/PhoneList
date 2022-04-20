using DataAccessLayer.Models.DTOs;
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
    public class CityController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync("https://localhost:44337/api/City/GetList/");
                var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
                var values = JsonConvert.DeserializeObject<List<CityDTO>>(jsonString); //listelerken
                return View(values);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(PersonDTO person)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44337/api/Person/Create/", content);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("GetList");
            }
            ModelState.AddModelError("", "Ekleme işlemi başarısız");
            return View(person);
        }

    }
}
