using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CarService.Models.Entities
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }
        public string TitleOrganization { get; set; } = null!;

        public int TIN { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string CorporateNumber { get; set; } = null!;

        public string CorporateEmail { get; set; } = null!;

        [NotMapped]
        public bool IsCorrectEmail
        {
            get
            {
                bool isContainsSeparator = false;
                bool isContainsDomen = false;

                foreach (char c in CorporateEmail)
                {
                    if (c == '@')
                    {
                        isContainsSeparator = true;
                    }
                    else if (c == '.' && isContainsSeparator)
                        isContainsDomen |= true;
                }

                if (CorporateEmail == string.Empty)
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
                MatchCollection matchNumber = rg.Matches(CorporateNumber);
                if (matchNumber.Count > 0) return true;
                else return false;
            }
        }

        [NotMapped]
        public bool IsCorrectTIN
        {
            get
            {
                if(TIN.ToString().Length == 10) return true;
                else return false;
            }
        }

        [NotMapped]
        public bool IsCorrectData
        {
            get
            {
                if(IsCorrectEmail && IsCorrectPhoneNumber
                    && TitleOrganization != string.Empty
                    && IsCorrectTIN && Address != string.Empty
                    && City != string.Empty) return true;
                else return false;
            }
        }
    }
}