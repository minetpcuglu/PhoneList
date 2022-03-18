using DataAccessLayer.BaseRepositories.BaseRepo.Interface;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface
{
   public interface IPersonRepository:IBaseRepositories<Person>
    {
    }
}
