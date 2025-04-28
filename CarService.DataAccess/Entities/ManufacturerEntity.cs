using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.Entities
{
    public class ManufacturerEntity
    {
        public Guid ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
        public string ContactInfo { get; set;  } = string.Empty;
        public List<AutoPartEntity> AutoParts { get; set; } = [];
    }
}
