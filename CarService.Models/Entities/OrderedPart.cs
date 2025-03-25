using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class OrderedPart
    {
        [Key]
        public int OrderedPartId { get; set; }
        public Order Order { get; set; } = null!;
        public AutoPart AutoPart { get; set; } = null!;
        public int Amount { get; set; }
    }
}
