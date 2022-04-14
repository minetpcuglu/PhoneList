using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListAPI.Entity
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual bool IsDeleted { get; set; } = false;

        //ilişkiler
        public virtual List<Contact> Contacts { get; set; }
    }
}
