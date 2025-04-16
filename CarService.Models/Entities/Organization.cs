namespace CarService.Models.Entities
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }
        public string TitleOrganization { get; set; } = null!;

        public int TIN { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string CorporateNumber { get; set; } = null!;

        public string CorporateEmail { get; set; } = null!;
    }
}