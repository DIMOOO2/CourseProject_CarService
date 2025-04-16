using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;

        [ForeignKey("OrganizationId")]
        public Organization? Organization { get; set; } = null!;

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [NotMapped]
        public string GetEmail
        {
            get
            {
                if (Organization != null)
                    return Organization.CorporateEmail;
                else
                    return Email;
            }
        }

        [NotMapped]
        public string GetNumber
        {
            get
            {
                if (Organization != null)
                    return Organization.CorporateNumber;
                else
                    return PhoneNumber;
            }
        }

    }
}
