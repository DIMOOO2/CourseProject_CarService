namespace CarService.DataAccess.Entities
{
    public class DeliveryReportEntity
    {
        public Guid ReportId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid WarehouseCreatorId { get; set; }
        public WarehouseEntity? WarehouseCreator { get; set; }
        public byte[] ReportFile { get; set; } = null!;
    }
}
