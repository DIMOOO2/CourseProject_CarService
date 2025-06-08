namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса автозачасти
    /// </summary>
    /// <param name="autoPartName">Название</param>
    /// <param name="partNumber">Партийный номер</param>
    /// <param name="price">Цена</param>
    /// <param name="stockAmount">Количество</param>
    /// <param name="manufacturerId">ID производителя</param>
    /// <param name="warehouseId">ID склада</param>
    public record AutoPartRequest
        (
            string autoPartName, 
            long partNumber,
            decimal price,
            uint stockAmount, 
            Guid manufacturerId, 
            Guid? warehouseId
        );
}
