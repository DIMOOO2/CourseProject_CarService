namespace CarService.newWebAPI.Contracts.Requests
{
    public record OrganizationRequest(string titleOrganization, long tIN,
            string address, string city);
}
