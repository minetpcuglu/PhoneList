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
        Task Add(ContactDTO contactDTO);
        Task<ContactDTO> GetByIdContact(int id);
    }
}
