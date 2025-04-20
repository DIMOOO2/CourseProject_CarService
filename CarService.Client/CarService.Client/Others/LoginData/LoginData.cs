using CarService.Models.Entities;


namespace CarService.Client.Others.LoginData
{
    public static class LoginData
    {
        public static Warehouse? CurrentWarehouse { get; set; }

        public static void SetWarehouse(Warehouse? warehouse)
        {
            CurrentWarehouse = warehouse;
        }
    }
}
