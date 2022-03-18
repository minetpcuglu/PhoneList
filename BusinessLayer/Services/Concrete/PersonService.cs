using BusinessLayer.Services.Interface;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.Context;
using DataAccessLayer.UnitOfWorks.Interface;
using EntityLayer.Entities.Concrete;
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
        public async Task Add(Person personDTO)
        {
            await _unitOfWork.PersonRepository.Insert(personDTO);
            await _unitOfWork.Commit();

        }

        public async Task<List<Person>> GetAll()
        {
            var list = await _unitOfWork.PersonRepository.GetAll();
            await _unitOfWork.Commit();
            return list;
        }
    }
}
