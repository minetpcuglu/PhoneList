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
   public class ContactRepository : Repository<Contact>, IContactRepository  // => Repository<City> tipinde kalıtım aldık. Daha sonra inject edeceğimiz ICityRepository tanımladık. Bunu yapmamızın amacı DIP prensibine uymamız. Sınıfları olabildiğince birbirinden bağımsız hale getirmek.
    {
        public ContactRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { } //=> Database bağlantısını yaptık.
    }
}
