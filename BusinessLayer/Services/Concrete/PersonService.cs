using AutoMapper;
using BusinessLayer.Services.Interface;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.Context;
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.UnitOfWorks.Interface;
using EntityLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICityRepository _cityRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ApplicationDbContext _context;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository, ApplicationDbContext applicationDbContext, IMapper mapper, ICityRepository cityRepository, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _context = applicationDbContext;
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _cityRepository = cityRepository;
            _contactRepository = contactRepository;

        }
        public async Task Add(PersonDTO personDTO)
        {
            if (personDTO != null)
            {
                var addPerson = _mapper.Map<PersonDTO, Person>(personDTO);
                addPerson.Status = true;
                await _unitOfWork.PersonRepository.Insert(addPerson);
                await _unitOfWork.Commit();
            }

        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var deletePerson = await _unitOfWork.PersonRepository.Get(x => x.Id == id);
                deletePerson.Status = false;
                deletePerson.IsDeleted = true;
                _unitOfWork.PersonRepository.Delete(deletePerson);
                await _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            var list = await _personRepository.GetFilteredList(
                selector: x => new PersonDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName = x.FullName,


                    ContactDTOs = x.Contacts.Select(y => new ContactDTO { CityId = y.Id, EMail = y.EMail, PhoneNumber = y.PhoneNumber }).ToList()
                }, expression: x => x.Status == true);

            return list;
        }

        public async Task<PersonDTO> GetById(int id)
        {
            if (id != 0)
            {
                var person = _personRepository.GetQueryable();

                var result = new PersonDTO
                {
                    Id = id,
                    FirstName = person.Where(x => x.Id == id).Select(x => x.FirstName).FirstOrDefault(),
                    FullName = person.Where(x => x.Id == id).Select(x => x.FullName).FirstOrDefault(),
                    LastName = person.Where(x => x.Id == id).Select(x => x.LastName).FirstOrDefault(),

                };

                return result;
            }
            return null;
        }

        public async Task<List<LocationReportDTO>> GetPersonLocationReport()
        {
            var contact = await _cityRepository.GetQueryable().Include(x => x.Contacts).ToListAsync();

            var getres = contact.SelectMany(x => x.Contacts).Select(x => new LocationReportDTO
            {
                Location = x.City.Name,
                Id = x.City.Id
            });

            var result = getres.GroupBy(x => x.Location).ToList();
            List<LocationReportDTO> listModel = new List<LocationReportDTO>();

            foreach (var item in result)
            {
                var newModel = new LocationReportDTO();
                newModel.Location = item.Key;
                newModel.TotalLocation = item.Count();
                listModel.Add(newModel);
            }

            var list = listModel.OrderByDescending(x => x.TotalLocation).ToList();

            return list;
        }

        public async Task<int> PhoneToCityReport(int id)
        {
            var query = _contactRepository.GetQueryable().Where(x => x.CityId == id).ToList().Count;

            return query;
        }

        public async Task Update(PersonDTO personDTO)
        {
            var value = _mapper.Map<PersonDTO, Person>(personDTO);
            if (value.Id != 0)
            {
                value.Status = true;
                await _unitOfWork.PersonRepository.Update(value);
                await _unitOfWork.SaveChangesAsync();

            }
        }
    }
}
