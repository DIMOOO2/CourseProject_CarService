namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запсиь ответа учетной записи склада
    /// </summary>
    /// <param name="accountId">Id учетной записи</param>
    /// <param name="logIn">Логин</param>
    /// <param name="password">Пароль</param>
    /// <param name="warehouseId">ID склада</param>
    public record CorporateAccountResponse(Guid accountId, string logIn, string password, Guid warehouseId);
}
