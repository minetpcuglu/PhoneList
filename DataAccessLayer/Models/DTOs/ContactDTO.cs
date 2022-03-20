using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
   public class ContactDTO
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public  int PersonId { get; set; }
        public  int CityId { get; set; }
        public  string CityName { get; set; }
        public List<CityDTO> Cities { get; set; }

    }
}
