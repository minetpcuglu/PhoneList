using Microsoft.EntityFrameworkCore;
using PhoneListWebAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListWebAPI.DataAccessLayer
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options) : base(options) { } // =>  "DB bağlantısını concructor method ile oluşturuldu."
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
