namespace CarService.ApplicationService.Contracts.Responses
{
    public record DeliveryReportResponse(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] fileReport);
}
