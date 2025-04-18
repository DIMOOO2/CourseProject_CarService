using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarService.Models.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;

        [ForeignKey("OrganizationId")]
        public Organization? Organization { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName} {MiddleName}";
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

        [NotMapped]
        public bool IsCorrectName
        {
            get
            {
                foreach (char c in $"{FirstName}{LastName}{MiddleName}")
                {
                    if (c < '0' || c > '9')
                        return false;
                }

                if (FirstName == string.Empty || LastName == string.Empty)
                    return false;

                else return true;
            }
        }

        [NotMapped]
        public bool IsCorrectEmail
        {
            get
            {
                bool isContainsSeparator = false;
                bool isContainsDomen = false;

                foreach (char c in Email)
                {
                    if (c == '@')
                    {
                        isContainsSeparator = true;
                    }
                    else if (c == '.' && isContainsSeparator)
                        isContainsDomen |= true;
                }

                if (Email == string.Empty)
                    return false;

                else if (!isContainsDomen || !isContainsSeparator)
                    return false;

                else return true;
            }      
        }

        [NotMapped]
        public bool IsCorrectPhoneNumber
        {
            get
            {
                Regex rg = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");
                MatchCollection matchNumber = rg.Matches(PhoneNumber);
                if (matchNumber.Count > 0) return true;
                else return false;
            }          
        }

    }
}
