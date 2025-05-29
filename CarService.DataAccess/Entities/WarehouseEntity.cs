namespace CarService.DataAccess.Entities
{
    public class WarehouseEntity
    {
        public Guid WarehouseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set;  } = string.Empty;
        public List<AutoPartEntity> AutoParts { get; set; } = [];
        public List<OrderEntity> Orders { get; set; }
    }
}
