using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
   public class Contact
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        /*İlişkiler*/
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }

        public virtual City City { get; set; }
        public int CityId { get; set; }
    }
}
