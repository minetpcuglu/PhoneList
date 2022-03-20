using BusinessLayer.Services.Interface;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
   public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityDTO>> CityList()
        {
            var value = await _cityRepository.GetFilteredList(
                selector: x => new CityDTO
                {
                    CityName = x.Name,
                    Id = x.Id,
                });
            return value;
                
        }
    }
}
