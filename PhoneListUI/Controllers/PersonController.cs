using BusinessLayer.Services.Interface;
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

        public async Task<IActionResult> Index()
        {
            var result = await _personServices.GetAll();

            return View(result);
        }
    
    }
}
