namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа клиента
    /// </summary>
    /// <param name="clientId">ID клиента</param>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="middleName">Отчетсво</param>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <param name="email">Электронная почта</param>
    /// <param name="address">Адрес</param>
    /// <param name="city">Город</param>
    /// <param name="organizationId">ID организации</param>
    public record ClientResponse(Guid clientId, string firstName, string lastName, string? middleName,
            string phoneNumber, string email, string address, string city, Guid? organizationId);
}
