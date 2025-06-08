namespace CarService.ApplicationService.Contracts.Responses
{
    /// <summary>
    /// Запись ответа производителя
    /// </summary>
    /// <param name="manufacturerId">ID производителя</param>
    /// <param name="manufacturerName">Название</param>
    /// <param name="contactInfo">Контактная информация (электронная почта)</param>
    public record ManufacturerResponse(Guid manufacturerId, string manufacturerName, string contactInfo);
}
