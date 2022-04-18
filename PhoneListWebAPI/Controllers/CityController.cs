using BusinessLayer.Services.Interface;
using DataAccessLayer.Models.DTOs;
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
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityServices;
        public CityController(ICityService cityService)
        {
            _cityServices = cityService;
        }
        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType(typeof(List<CityDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _cityServices.CityList());
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CityDTO city)
        {
            return Ok(await _cityServices.Add(city));
        }
    }
}
