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
        public async Task<bool> Add(ContactDTO contactDTO)
        {
            if (contactDTO != null)
            {
                var addContact = _mapper.Map<ContactDTO, Contact>(contactDTO);
                addContact.Status = true;

                try
                {
                    await _contactRepository.Insert(addContact);
                }
                catch (Exception ex)
                {

                    throw;
                }
                await _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        //public async Task<bool> Delete(int id)
        //{
        //    //if (id != 0)
        //    //{

        //    //    await _contactRepository.Delete(id);
        //    //    return true;
        //    //}
        //    return false;
        //}

        public async Task<ContactDTO> GetByIdContact(int id)
        {
            if (id != 0)
            {
                var contactInfo = await _contactRepository.GetFilteredFirstOrDefault(
                    selector: x => new ContactDTO
                    {
                        Id = x.PersonId,
                        EMail = x.EMail,
                        PhoneNumber = x.PhoneNumber,
                        CityId = x.City.Id,
                        CityName = x.City.Name,
                        PersonId = x.Person.Id,
                        FullName = x.Person.FullName

                    },
                    expression: x => x.PersonId== id && x.Status == true,
                    inculude: x => x.Include(x => x.City),
                    thenInculude: x => x.Include(x => x.Person)
                    ) ;
               
                return contactInfo;
            }
            return null;
        }

        public async Task<List<ContactDTO>> GetByIdContactInfo(int personId)
        {
            if (personId != 0)
            {
                var contactInfo = await _contactRepository.GetFilteredList(
                    selector: x => new ContactDTO
                    {
                        Id = x.Id,
                        EMail = x.EMail,
                        PhoneNumber = x.PhoneNumber,
                        CityId = x.City.Id,
                        CityName = x.City.Name,
                        PersonId = x.Person.Id,
                        FullName = x.Person.FullName
                    },
                    expression: x => x.PersonId == personId && x.Status == true,
                    inculude: x => x.Include(x => x.City),
                    thenInculude: x => x.Include(x => x.Person)
                    );
                return contactInfo;
            }
            return null;
        }

        public async Task<bool> Update(ContactDTO contactDTO)
        {
            if (contactDTO != null)
            {
                //var result = new Contact(contactDTO.Id, contactDTO.EMail, contactDTO.PhoneNumber, contactDTO.PersonId, contactDTO.CityId);
                var updateContact = _mapper.Map<ContactDTO, Contact>(contactDTO);
                updateContact.Status = true;

                try
                {
                    await _contactRepository.Update(updateContact);
                }
                catch (Exception ex)
                {

                    throw;
                }

                await _unitOfWork.SaveChangesAsync();

                return true;
               
            } 
            return false;


        }


        //public async Task<ContactDTO> DeleteAsync(int contactId)
        public async Task<bool> DeleteAsync(int contactId)
        {
            var result = await _unitOfWork.ContactRepository.AnyAsync(a => a.Id == contactId);
            if (result == true)
            {
                var person = await _unitOfWork.PersonRepository.GetAsync2(a => a.Id == contactId);
                person.IsDeleted = true;
                person.Status = false;

                await _unitOfWork.PersonRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
