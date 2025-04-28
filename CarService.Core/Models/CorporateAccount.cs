using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class CorporateAccount
    {
        private CorporateAccount(Guid accountId, string logIn, string password, Warehouse warehouse)
        {
            AccountId = accountId;
            LogIn = logIn;
            Password = password;
            Warehouse = warehouse;
        }

        public Guid AccountId { get; }
        public string LogIn { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public Warehouse Warehouse { get; } = null!;

        public static (CorporateAccount CorporateAccount, string error) Create(Guid accountId, string logIn, string password, Warehouse warehouse)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(logIn) || string.IsNullOrEmpty(password)
                || warehouse == null)
            {
                error = "Error account is not created";
            }

            CorporateAccount corporateAccount = new CorporateAccount(accountId, logIn, password, warehouse!);

            return (corporateAccount, error);
        }
    }
}
