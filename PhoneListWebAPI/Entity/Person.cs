using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListWebAPI.Entity
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool Status { get; set; } /*= true;*/
        public virtual bool IsDeleted { get; set; } = false;

        //ilişkiler
        public virtual List<Contact> Contacts { get; set; }
    }
}
