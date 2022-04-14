using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListAPI.Entity
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public virtual bool IsDeleted { get; set; } = false;

        /*İlişkiler*/
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }

        public virtual City City { get; set; }
        public int CityId { get; set; }
    }
}
