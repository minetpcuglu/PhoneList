using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
   public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //ilişkiler
        //public virtual List<Contact> Contacts { get; set; }
    }
}
