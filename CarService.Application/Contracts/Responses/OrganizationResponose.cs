namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа организации
    /// </summary>
    /// <param name="organizationId">ID организации</param>
    /// <param name="titleOrganization">Название</param>
    /// <param name="tIN">ИНН</param>
    /// <param name="address">Адрес</param>
    /// <param name="city">Город</param>
    public record OrganizationResponose(Guid organizationId, string titleOrganization, long tIN,
            string address, string city);
}
