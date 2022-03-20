using AutoMapper;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities.AutoMapper
{
   public class CityMapping:Profile
    {
        public CityMapping()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<CityDTO, City>().ReverseMap();
        }
    }
}
