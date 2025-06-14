﻿using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    /// <summary>
    /// Контроллер производителя
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="manufacturerService">Интерфейс для работы с производителями</param>
        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        /// <summary>
        /// Получение всех производителей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ManufacturerResponse>>> GatManufacturers()
        {
            var manufacturers = await _manufacturerService.GetAllManufacturers();

            var response = manufacturers.Select(m => new ManufacturerResponse(
                m.ManufacturerId,
                m.ManufacturerName,
                m.ContactInfo));

            return Ok(response);
        }

        /// <summary>
        /// Получение производителя по ID
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<ManufacturerResponse>>> GatManufacturerById(Guid id)
        {
            var manufacturer = await _manufacturerService.GetByIdManufacturer(id);

            if (manufacturer != null)
            {
                var response = new ManufacturerResponse(
                manufacturer.ManufacturerId,
                manufacturer.ManufacturerName,
                manufacturer.ContactInfo);

                return Ok(response);
            }
            else return NotFound(manufacturer);
        }

        /// <summary>
        /// Добавление производителя
        /// </summary>
        /// <param name="request">Данные нового производителя</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ManufacturerResponse>> CreateManufacturer([FromBody] ManufacturerRequest request)
        {
            var (manufacturer, error) = Manufacturer.Create
                (
                    Guid.NewGuid(),
                    request.manufacturerName,
                    request.contactInfo
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _manufacturerService.CreateManufacturer(manufacturer);

            return Ok(new ManufacturerResponse(manufacturer.ManufacturerId, manufacturer.ManufacturerName, manufacturer.ContactInfo));
        }

        /// <summary>
        /// Обновление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <param name="request">Новые данные производителя</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateManufacturer(Guid id, [FromBody] ManufacturerRequest request)
        {
            var manufacturerId = await _manufacturerService.UpdateManufacturer(id,
                request.manufacturerName,
                request.contactInfo);

            return Ok(manufacturerId);
        }

        /// <summary>
        /// Удаление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ManufacturerRequest>> DeleteWarehouse(Guid id)
        {
            return Ok(await _manufacturerService.DeleteManufacturer(id));
        }
    }
}
