using System.ComponentModel.DataAnnotations;


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
