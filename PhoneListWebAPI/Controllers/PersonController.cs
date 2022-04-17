using BusinessLayer.Services.Interface;
using DataAccessLayer.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using PhoneListWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneListWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personServices;
        public PersonController(IPersonService personService)
        {
            _personServices = personService;
        }

        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType(typeof(List<PersonDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _personServices.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] PersonDTO person)
        {
            return Ok(await _personServices.Add(person));
        }

        [HttpDelete]
        [Route("{id}/Delete")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personServices.DeleteAsync(id);
            return Ok(result);
        }
    }

   
}
