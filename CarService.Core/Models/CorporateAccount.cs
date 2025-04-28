using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class CorporateAccount
    {
        private CorporateAccount(Guid accountId, string logIn, string password, Guid warehouseId)
        {
            AccountId = accountId;
            LogIn = logIn;
            Password = password;
            WarehouseId = warehouseId;
        }

        public Guid AccountId { get; }
        public string LogIn { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public Guid WarehouseId { get; }

        public static (CorporateAccount CorporateAccount, string error) Create(Guid accountId, string logIn, string password, Guid warehouse)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(logIn) || string.IsNullOrEmpty(password)
                || warehouse == Guid.Empty)
            {
                error = "Error account is not created";
            }

            CorporateAccount corporateAccount = new CorporateAccount(accountId, logIn, password, warehouse!);

            return (corporateAccount, error);
        }
    }
}
