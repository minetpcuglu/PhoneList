using BusinessLayer.Services.Interface;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.Context;
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationDbContext _context;
      
        public PersonService( IUnitOfWork unitOfWork, IPersonRepository personRepository, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;

        }
        //public async Task Add(PersonDTO personDTO)
        //{
        //    //await _unitOfWork.PersonRepository.Insert(personDTO);
        //    //await _unitOfWork.Commit();
        //    return null;

        //}

        public async Task<List<PersonDTO>> GetAll()
        {
            var list = await _personRepository.GetFilteredList(
                selector: x => new PersonDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName =x.FullName,
                    
                    ContactDTOs = x.Contacts.Select(y => new ContactDTO { CityId = y.Id, EMail = y.EMail, PhoneNumber = y.PhoneNumber }).ToList()
                });
          
            return list;
        }
    }
}
