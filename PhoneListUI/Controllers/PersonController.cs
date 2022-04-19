
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneListUI.Controllers
{
    public class PersonController : Controller
    {
        //hepsi calısıyor 
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
        public IActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Insert(PersonDTO person)
        {
       
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44337/api/Person/Insert/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetList");
            }
            ModelState.AddModelError("", "Ekleme işlemi başarısız");
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                using (var httpClient = new HttpClient())
                {
                    var responseMessage = await httpClient.DeleteAsync("https://localhost:44337/api/Person/" + id);
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
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            //var value = await _personServices.GetById(id);
            //return View(value);
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync("https://localhost:44337/api/Person/"+ id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonPerson = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<PersonDTO>(jsonPerson);
                    return View(value);
                }
                return RedirectToAction("GetList");

            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(PersonDTO person)
        {
            using (var httpClient = new HttpClient())
            {
                var value = JsonConvert.SerializeObject(person);
                var content = new StringContent(value, Encoding.UTF8, "application/json");

                var responseMessage = await httpClient.PostAsync("https://localhost:44337/api/Person/PersonUpdate/", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetList");
                }
                return View(person);
            }
        }

        ////konuma göre rapor getirme
        [HttpGet]
        public async Task<IActionResult> PersonLocationReport()
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync("https://localhost:44337/api/Person/PersonLocationReport/");
                var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
                var values = JsonConvert.DeserializeObject<List<LocationReportDTO>>(jsonString); //listelerken
                return View(values);
          
            }
           
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
