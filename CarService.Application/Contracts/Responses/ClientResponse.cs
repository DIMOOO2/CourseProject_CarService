namespace CarService.ApplicationService.Contracts.Responses
{
    public record ClientResponse(Guid clientId, string firstName, string lastName, string? middleName,
            string phoneNumber, string email, string address, string city, Guid? organizationId);
}
