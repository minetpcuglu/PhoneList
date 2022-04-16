using DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interface
{
   public interface IContactService
    {
        Task<bool> Add(ContactDTO contactDTO);
        Task<ContactDTO> GetByIdContact(int id);
        //Task<bool> Delete(int id);
        //Task<ContactDTO> DeleteAsync(int contactId);
        Task<bool> DeleteAsync(int contactId);
   
        Task<List<ContactDTO>> GetByIdContactInfo(int personId);
        //Task<List<PersonDTO>> GetByIdContactInfo(int personId);
        Task<bool> Update(ContactDTO contactDTO);
    }
}
