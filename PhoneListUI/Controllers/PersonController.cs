
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneListWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneListUI.Controllers
{
    public class PersonController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync("https://localhost:44337/api/Person/GetList/");
                var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
                var values = JsonConvert.DeserializeObject<List<PersonDTO>>(jsonString); //listelerken
                return View(values);
            }
            //var value = await _personServices.GetAll();
            //return View(value);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(PersonDTO person)
        {
            using (var client = new HttpClient())
            {
                var jsonPerson = JsonConvert.SerializeObject(person); //eklersen 
                StringContent content = new StringContent(jsonPerson, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44337/api/Person/Create/", content);
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("GetList");
                }
                ModelState.AddModelError("", "Ekleme işlemi başarısız");
                return View(person);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                using (var httpClient = new HttpClient())
                {
                    var responseMessage = await httpClient.DeleteAsync("https://localhost:44337/api/Person/Delete/" + id);
                    if (responseMessage.IsSuccessStatusCode)
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
            }
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult>  Update(int id)
        //{
        //    var value = await _personServices.GetById(id);
        //    return View(value);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(PersonDTO person)
        //{
        //    await _personServices.Update(person);
        //    return RedirectToAction("GetList");
        //}

        ////konuma göre rapor getirme
        //[HttpGet]
        //public async Task<IActionResult> PersonLocationReport()
        //{
        //    var person = await _personServices.GetPersonLocationReport();
        //    return View(person);
        //}

    }
}
