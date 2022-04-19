using BusinessLayer.Services.Interface;
using DataAccessLayer.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PhoneListWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactServices;
        private readonly ICityService _cityService;
        public ContactController(IContactService contactService, ICityService cityService)
        {
            _cityService = cityService;
            _contactServices = contactService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ContactDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdContactInfo(int id)
        {
            var result = await _contactServices.GetByIdContactInfo(id);
            return Ok(result);
        }


        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] ContactDTO contact)
        {
            return Ok(await _contactServices.Add(contact));
        }

        //[HttpGet]
        //[Route("{id}/GetByContactInfo")]
        //[ProducesResponseType(typeof(List<ContactDTO>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //public async Task<IActionResult> GetByIdContactInfo(int id)
        //{
        //    var result = await _contactInfoService.GetByIdContactInfo(id);
        //    return Ok(result);
        //}
    }
}
