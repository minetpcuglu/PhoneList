﻿using DataAccessLayer.Models.DTOs;
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
        Task Delete(int id);

        //Task<HobbyDTO> GetById(int id);
        //Task Update(HobbyDTO hobbyDTO);
        //Task<bool> Delete(int id);
    }
}
