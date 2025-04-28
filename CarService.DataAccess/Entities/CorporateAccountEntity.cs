using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.Entities
{
    public class CorporateAccountEntity
    {
        public Guid AccountId { get; set; }
        public string LogIn { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid WarehouseId { get; set; }
        public WarehouseEntity? Warehouse { get; set; } = null!;
    }
}
