using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class Client
    {
        private Client(Guid clientId, string firstName, string lastName, string? middleName, 
            string phoneNumber, string email, string address, string city, Guid? organizationId)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            City = city;
            OrganizationId = organizationId;
        }
        public Client()
        {         
        }
        public Guid ClientId { get; }
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string? MiddleName { get; } = string.Empty;
        public string PhoneNumber { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Address { get; } = string.Empty;
        public string City { get; } = string.Empty;
        public Guid? OrganizationId { get; }

        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }

        public static (Client Client, string error) Create(Guid clientId, string firstName, 
            string lastName, string? middleName,
            string phoneNumber, string email, string address, string city, Guid? organization)
        {
            string error = string.Empty;

            string[] requiredParams = { firstName, lastName, phoneNumber, email, address, city};

            foreach(string param in requiredParams)
            {
                if (string.IsNullOrEmpty(param))
                {
                    error = "Error client is not created";
                    break;
                }                                    
            }

            Client client = new Client(clientId, firstName, lastName, middleName, 
                phoneNumber, email, address, city, organization);

            return (client, error);
        }
    }
}
