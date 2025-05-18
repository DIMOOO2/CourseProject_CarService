namespace CarService.ApplicationService.Contracts.Requests
{
    public record DeliveryReportRequest(Guid id, DateTime createDate, Guid warehouseCreatorId, byte[] fileReport);
}
