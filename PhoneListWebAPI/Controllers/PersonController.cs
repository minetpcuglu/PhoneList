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
        //hepsi calısıyor 
        private readonly IPersonService _personServices;
        public PersonController(IPersonService personService)
        {
            _personServices = personService;
        }

        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType(typeof(List<PersonDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetListPerson()
        {
            return Ok(await _personServices.GetAll());
        }

        [HttpPost]
        [Route("Insert")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] PersonDTO person)
        {
            return Ok(await _personServices.Add(person));
        }

        //[HttpDelete]
        //[Route("{id}/Delete")]
        //[ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await _personServices.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDTO person)
        {
            var result = await _personServices.Update(person);
            return Ok(result);
        }

        [HttpGet]
        [Route("PersonLocationReport")]
        [ProducesResponseType(typeof(List<PersonDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PersonRaport()
        {
            return Ok(await _personServices.GetPersonLocationReport());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdPerson(int id)
        {
            var result = await _personServices.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("PersonUpdate")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PersonUpdate([FromBody] PersonDTO person)
        {
            var result = await _personServices.Update(person);
            return Ok(result);
        }
    }
}
