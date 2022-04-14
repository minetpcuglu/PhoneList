using DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interface
{
   public interface IPersonService
    {
        Task<List<PersonDTO>> GetAll();
        Task Add(PersonDTO personDTO);
        Task<bool> Delete(int id);
        Task<List<LocationReportDTO>> GetPersonLocationReport();
        public Task<int> PhoneToCityReport(int id);
        Task<PersonDTO> GetById(int id);
        Task Update(PersonDTO personDTO);
        Task<bool> DeleteAsync(int personId);
        //Task<List<PersonDTO>> GetAsync(int articleId);

        //Task<bool> Delete(int id);
    }
}
