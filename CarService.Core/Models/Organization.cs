using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class Organization
    {
        const int COUNT_SYMBOLS_TIN = 10;
        private Organization(Guid organizationId, string titleOrganization, long tIN, string address, string city)
        {
            OrganizationId = organizationId;
            TitleOrganization = titleOrganization;
            TIN = tIN;
            Address = address;
            City = city;
        }

        public Guid OrganizationId { get; }
        public string TitleOrganization { get; } = string.Empty;
        public long TIN { get; }
        public string Address { get; } = string.Empty;
        public string City { get; } = string.Empty;

        public static (Organization Organization, string error) Create(Guid organizationId, string titleOrganization, long tIN, string address, string city)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(titleOrganization) || string.IsNullOrEmpty(address)
                || string.IsNullOrEmpty(city) || tIN.ToString().Length != COUNT_SYMBOLS_TIN)
            {
                error = "Error organization is not created";
            }

            Organization organization = new Organization(organizationId, titleOrganization, tIN, address, city);

            return (organization, error);
        }
    }
}