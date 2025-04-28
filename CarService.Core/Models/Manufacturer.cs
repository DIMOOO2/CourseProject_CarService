using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class Manufacturer
    {
        private Manufacturer(Guid manufacturerId, string manufacturerName, string contactInfo)
        {
            ManufacturerId = manufacturerId;
            ManufacturerName = manufacturerName;
            ContactInfo = contactInfo;
        }

        public Guid ManufacturerId { get; }
        public string ManufacturerName { get; } = string.Empty;
        public string ContactInfo { get; } = string.Empty;

        public static (Manufacturer Manufacturer, string error) Create(Guid id, string name, string contactInfo)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contactInfo))
            {
                error = "Error manufacturer is not created";
            }

            Manufacturer manufacturer = new Manufacturer(id, name, contactInfo);

            return (manufacturer, error);
        }
    }
}
