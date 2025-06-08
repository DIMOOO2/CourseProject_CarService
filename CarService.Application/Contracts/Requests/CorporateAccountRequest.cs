namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запсиь запроса учетной записи склада
    /// </summary>
    /// <param name="logIn">Логин</param>
    /// <param name="password">Пароль</param>
    /// <param name="warehouseId">ID склада</param>
    public record CorporateAccountRequest
        (
            string logIn, string password, Guid warehouseId
        );
}
