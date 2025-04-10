using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class Manufacturer
    {
        [Key]
        public Guid ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string ContactInfo { get; set; } = null!;
    }
}
