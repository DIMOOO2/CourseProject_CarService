namespace CarService.ApplicationService.Contracts.Requests
{
    /// <summary>
    /// Запись запроса производителя
    /// </summary>
    /// <param name="manufacturerName">Название</param>
    /// <param name="contactInfo">Контактная информация (электронная почта)</param>
    public record ManufacturerRequest
        (
            string manufacturerName, string contactInfo
        );
}
