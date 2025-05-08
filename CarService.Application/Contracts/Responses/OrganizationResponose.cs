namespace CarService.ApplicationService.Contracts.Responses
{
    public record OrganizationResponose(Guid organizationId, string titleOrganization, long tIN,
            string address, string city);
}
