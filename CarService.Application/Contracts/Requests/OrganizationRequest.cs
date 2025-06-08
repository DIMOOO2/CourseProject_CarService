namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса организации
    /// </summary>
    /// <param name="titleOrganization">Название</param>
    /// <param name="tIN">ИНН</param>
    /// <param name="address">Адрес</param>
    /// <param name="city">Город</param>
    public record OrganizationRequest(string titleOrganization, long tIN,
            string address, string city);
}
