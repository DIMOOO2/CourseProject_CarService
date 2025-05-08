using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.Application.Services
{
    public class AutoPartService : IAutoPartService
    {
        private readonly IAutoPartRepository _autoPartRepository;

        public AutoPartService(IAutoPartRepository autoPartRepository)
        {
            _autoPartRepository = autoPartRepository;
        }

        public async Task<List<AutoPart>> GetAllAutoParts()
        {
            return await _autoPartRepository.Get();
        }

        public async Task<AutoPart> GetByIdAutoPart(Guid id)
        {
            return await _autoPartRepository.GetById(id);
        }

        public async Task<Guid> CreateAutopart(AutoPart autoPart)
        {
            return await _autoPartRepository.Create(autoPart);
        }

        public async Task<Guid> UpdateAutoPart(Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId)
        {
            return await _autoPartRepository.Update(autoPartId, autoPartName, partNumber, price,
                stockAmount, manufacturerId, warehouseId);
        }

        public async Task<Guid> DeleteAutoPart(Guid id)
        {
            return await _autoPartRepository.Delete(id);
        }
    }
}
