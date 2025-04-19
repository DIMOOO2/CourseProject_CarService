using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CarService.Models.Entities
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }
        public string TitleOrganization { get; set; } = null!;
        public long TIN { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;



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
                if(TitleOrganization != string.Empty
                    && IsCorrectTIN && Address != string.Empty
                    && City != string.Empty) return true;
                else return false;
            }
        }
    }
}