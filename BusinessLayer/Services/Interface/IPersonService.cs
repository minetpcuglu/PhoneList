using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interface
{
   public interface IPersonService
    {
        Task<List<Person>> GetAll();
        Task Add(Person personDTO);
        //Task<HobbyDTO> GetById(int id);
        //Task Update(HobbyDTO hobbyDTO);
        //Task<bool> Delete(int id);
    }
}
