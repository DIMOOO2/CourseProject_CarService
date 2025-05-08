namespace CarService.ApplicationService.Contracts.Requests
{
    public record ClientRequest
        (
            string firstName, 
            string lastName, 
            string? middleName,
            string phoneNumber, 
            string email, 
            string address, 
            string city, 
            Guid? organizationId
        );
}
