namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа автозачасти
    /// </summary>
    /// <param name="autoPartId">ID автозачасти</param>
    /// <param name="autoPartName">Название</param>
    /// <param name="partNumber">Партийный номер</param>
    /// <param name="price">Цена</param>
    /// <param name="stockAmount">Количество</param>
    /// <param name="manufacturerId">ID производителя</param>
    /// <param name="warehouseId">ID склада</param>
    public record AutoPartResponse
        (
            Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId
        );
}
