using CarService.Core.Abstractions;
using CarService.Core.Models;


namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы с производителем
    /// </summary>
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="manufacturerRepository"></param>
        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        /// <summary>
        /// Получение всех производителей
        /// </summary>
        /// <returns></returns>
        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            return await _manufacturerRepository.Get();
        }

        /// <summary>
        /// Получение производителя по ID
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        public async Task<Manufacturer> GetByIdManufacturer(Guid id)
        {
            return await _manufacturerRepository.GetById(id);
        }

        /// <summary>
        /// Создание производителя
        /// </summary>
        /// <param name="manufacturer">Новый производитель</param>
        /// <returns></returns>
        public async Task<Guid> CreateManufacturer(Manufacturer manufacturer)
        {
            return await _manufacturerRepository.Create(manufacturer);
        }

        /// <summary>
        /// Обновление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <param name="name">Название</param>
        /// <param name="contactInfo">Контектная информация (email)</param>
        /// <returns></returns>
        public async Task<Guid> UpdateManufacturer(Guid id, string name, string contactInfo)
        {
            return await _manufacturerRepository.Update(id, name, contactInfo);
        }

        /// <summary>
        /// Удаление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        public async Task<Guid> DeleteManufacturer(Guid id)
        {
            return await _manufacturerRepository.Delete(id);
        }
    }
}
