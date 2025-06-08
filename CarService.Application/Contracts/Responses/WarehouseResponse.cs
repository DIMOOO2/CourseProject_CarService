namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа склада
    /// </summary>
    /// <param name="Id">ID склада</param>
    /// <param name="Title">Название</param>
    /// <param name="Address">Адрес</param>
    /// <param name="City">Город</param>
    public record WarehouseResponse
        (
            Guid Id,
            string Title,
            string Address,
            string City
        );
}
