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
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<PersonDTO, Person>().ReverseMap();
        }
    }
}
