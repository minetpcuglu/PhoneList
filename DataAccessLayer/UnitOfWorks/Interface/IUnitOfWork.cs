using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorks.Interface
{
   public interface  IUnitOfWork : IAsyncDisposable
    {
        IPersonRepository PersonRepository { get; }
        IContactRepository ContactRepository { get; }
        ICityRepository CityRepository { get; }
        Task<int> SaveChangesAsync();

        Task Commit();  // => Başarılı bir işlemin sonucunda çalıştırılır. İşlemin başalamasından itibaren tüm değişikliklerin veri tabanına uygulanmasını temin eder.

     

    }

}
