using AutoMapper;
using BusinessLayer.Services.Interface;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.UnitOfWorks.Interface;
using EntityLayer.Entities.Concrete;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CityService(ICityRepository cityRepository, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
        public async Task<bool> Add(CityDTO cityDTO)
        {
            if (cityDTO != null)
            {
                var addCity = _mapper.Map<CityDTO,City>(cityDTO);
                addCity.Status = true;
                await _unitOfWork.CityRepository.Insert(addCity);
                await _unitOfWork.Commit();
                return true;
            }
            return false;

        }
    }
}
