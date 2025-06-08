namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса склада
    /// </summary>
    /// <param name="Title">Название</param>
    /// <param name="Address">Адрес</param>
    /// <param name="City">Город</param>
    public record WarehouseRequest
        (
            string Title,
            string Address,
            string City
        );
}
