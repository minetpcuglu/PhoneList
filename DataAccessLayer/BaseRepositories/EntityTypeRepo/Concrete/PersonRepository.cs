using DataAccessLayer.BaseRepositories.BaseRepo.Concrete;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.Context;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseRepositories.EntityTypeRepo.Concrete
{
   public class PersonRepository : Repository<Person>, IPersonRepository  // => Repository<person> tipinde kalıtım aldık. Daha sonra inject edeceğimiz IpersonRepository tanımladık. Bunu yapmamızın amacı DIP prensibine uymamız. Sınıfları olabildiğince birbirinden bağımsız hale getirmek.
    {
        public PersonRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { } //=> Database bağlantısını yaptık.
    }
}
