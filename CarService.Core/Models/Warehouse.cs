namespace CarService.Core.Models
{
    public class Warehouse
    {
        private Warehouse(Guid warehouseId, string title, string address, string city)
        {
            WarehouseId = warehouseId;
            Title = title;
            Address = address;
            City = city;
        }

        public Warehouse()
        {
        }

        public Guid WarehouseId { get; }
        public string Title { get; } = string.Empty;
        public string Address { get; } = string.Empty;
        public string City { get; } = string.Empty;

        public static (Warehouse Warehouse, string error) Create(Guid id, string title, string address, string city)
        {
            string error = string.Empty;

            if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(address) 
                || string.IsNullOrEmpty(city))
            {
                error = "Error warehouse is not created";
            }

            Warehouse warehouse = new Warehouse(id, title, address, city);

            return (warehouse, error);
        }

        public override string ToString()
        {
            return $"{Title}. Адрес: {City} {Address}";
        }
    }
}
