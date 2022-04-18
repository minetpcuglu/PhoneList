using DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interface
{
   public interface ICityService
    {
        Task<List<CityDTO>> CityList();
        Task<bool> Add(CityDTO cityDTO);
    }
}
