using DataAccessLayer.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
