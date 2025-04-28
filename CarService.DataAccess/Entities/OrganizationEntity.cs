using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.Entities
{
    public class OrganizationEntity
    {
        public Guid OrganizationId { get; set; }
        public string TitleOrganization { get; set; } = string.Empty;
        public long TIN { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public List<ClientEntity> Clients { get; set; } = [];
    }
}
