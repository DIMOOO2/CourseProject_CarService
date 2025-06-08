namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса клиента
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="middleName">Отчетсво</param>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <param name="email">Электронная почта</param>
    /// <param name="address">Адрес</param>
    /// <param name="city">Город</param>
    /// <param name="organizationId">ID организации</param>
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
