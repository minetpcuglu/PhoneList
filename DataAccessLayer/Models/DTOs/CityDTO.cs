using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
  public class CityDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public bool Status { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
