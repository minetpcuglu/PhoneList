using Microsoft.EntityFrameworkCore;
using PhoneListAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListAPI.DataAccessLayer
{
    public class ContextAPI:DbContext
    {
        public ContextAPI(DbContextOptions<ContextAPI> options) : base(options) { } // =>  "DB bağlantısını concructor method ile oluşturuldu."

        public DbSet<City> Cities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
