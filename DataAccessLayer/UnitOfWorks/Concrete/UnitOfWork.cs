using DataAccessLayer.BaseRepositories.EntityTypeRepo.Concrete;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.Context;
using DataAccessLayer.UnitOfWorks.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork // => IUnitOfWork'den implement yolu ile gövdelendireceğim methodlar alındı
    {
        private readonly ApplicationDbContext _db;
        private IDbContextTransaction _transation;

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db ?? throw new ArgumentNullException("Database Can Not To Be Null..!");
        }

        public async Task Commit() => await _db.SaveChangesAsync();
        //=> ??= Karar mekanizmasını başlattık. Bu karar mekanizması ya bize db bağlantısını verecek ya da ArgumentNullException ile hata mesajımı gönderecektir.


        private IPersonRepository _personRepository;
        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null) _personRepository = new PersonRepository(_db);
                return _personRepository;

            }
        }
        private IContactRepository _contactRepository;
        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository == null) _contactRepository = new ContactRepository(_db);
                return _contactRepository;

            }
        }
        private ICityRepository _cityRepository;
        public ICityRepository CityRepository
        {
            get
            {
                if (_cityRepository == null) _cityRepository = new CityRepository(_db);
                return _cityRepository;

            }
        }

        public async Task<int> SaveChangesAsync()
        {
            var transaction = _transation ?? _db.Database.BeginTransaction();
            var count = 0;

            using (transaction)
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }

            return count;
        }

        private bool isDisposing = false;       //?
        public async ValueTask DisposeAsync()
        {
            if (!isDisposing)
            {
                isDisposing = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);    // Nesnemizi tamamıyla temizlenmesini sağlayack.
            }
        }
        private async Task DisposeAsync(bool disposing)
        {
            if (disposing) await _db.DisposeAsync(); // => Üretilen db nesnemizi dispose ettik.
        }
    }
}
