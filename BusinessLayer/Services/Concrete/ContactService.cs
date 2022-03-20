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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ApplicationDbContext _context;

        public ContactService(IUnitOfWork unitOfWork, IContactRepository contactRepository, ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _context = applicationDbContext;
            _unitOfWork = unitOfWork;
            _contactRepository = contactRepository;

        }
        public async Task Add(ContactDTO contactDTO)
        {
            if (contactDTO != null)
            {
                var addContact = _mapper.Map<ContactDTO, Contact>(contactDTO);
                await _unitOfWork.ContactRepository.Insert(addContact);
                await _unitOfWork.Commit();
            }
        }

        public async Task<ContactDTO> GetByIdContact(int id)
        {
            if (id != 0)
            {
                var contactInfo = await _contactRepository.GetFilteredFirstOrDefault(
                    selector: x => new ContactDTO
                    {
                        Id = x.Id,
                        EMail = x.EMail,
                        PhoneNumber = x.PhoneNumber,
                        CityId = x.City.Id,
                        //CityName = x.City.Name,
                        PersonId = x.Person.Id,
                        //FullName = x.Person.FullName
                    },
                    expression: x => x.PersonId == id ,
                    inculude: x => x.Include(x => x.City),
                    thenInculude: x => x.Include(x => x.Person)
                    );
                return contactInfo;
            }
            return null;
        }
    }
}
