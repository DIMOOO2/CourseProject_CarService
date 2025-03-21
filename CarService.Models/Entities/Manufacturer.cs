using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class Manufacturer
    {
        int ManufacturerId { get; set; }
        string ManufacturerName { get; set; } = null!;
        string ContactInfo { get; set; } = null!;
    }
}
