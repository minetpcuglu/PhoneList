using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
   public class LocationReportDTO
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int TotalLocation { get; set; }
        public int TotalPhoneNumber { get; set; }
        public int TotalPerson { get; set; }
        public IEnumerable<LocationReportDTO> models { get; set; }
    }
}
