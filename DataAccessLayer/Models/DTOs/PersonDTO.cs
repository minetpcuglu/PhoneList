using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public bool Status { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public List<ContactDTO> ContactDTOs { get; set; }
    }
}
