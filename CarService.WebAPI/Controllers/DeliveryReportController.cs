using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Abstractions;
using CarService.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace CarService.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер отчетов по поставкам
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DeliveryReportController : ControllerBase
    {
        private IDeliveryReportService _service;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="service"></param>
        public DeliveryReportController(IDeliveryReportService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение всех отчетов по поставкам
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<DeliveryReportResponse>>> GetReports()
        {
            var reports = await _service.GetAllReports();

            var response = reports.Select(dr => new DeliveryReportResponse
            (
                dr.ReportId,
                dr.CreateDate,
                dr.WarehouseCreatorId,
                dr.ReportFile
            ));

            return Ok(response);
        }

        /// <summary>
        /// Получение отчета по ID
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DeliveryReportResponse>> GetReportById(Guid id)
        {
            var report = await _service.GetDeliveryReportById(id);

            if (report != null)
            {
                var response = new DeliveryReportResponse
                    (
                        report.ReportId,
                        report.CreateDate,
                        report.WarehouseCreatorId,
                        report.ReportFile
                    );

                return Ok(response);
            }

            else return NotFound(report);
        }

        /// <summary>
        /// Получение всех отчетов на конкретном складе
        /// </summary>
        /// <param name="warehouesId"></param>
        /// <returns></returns>
        [HttpGet("fromWarehouse/{warehouesId:guid}")]
        public async Task<ActionResult<ObservableCollection<DeliveryReportResponse>>> GetAutoPartFromCurrentWarehouse(Guid warehouesId)
        {
            var reportsFromWarehouse = await _service.GetDeliveryReportsFromWarehouse(warehouesId);

            var response = reportsFromWarehouse.Select(r => new DeliveryReportResponse
            (
                r.ReportId,
                r.CreateDate,
                r.WarehouseCreatorId,
                r.ReportFile
            ));

            return Ok(response);
        }

        /// <summary>
        /// Добавление нового отчета по поставке
        /// </summary>
        /// <param name="request">Данные отчета</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DeliveryReportResponse>> CreateReport([FromBody] DeliveryReportRequest request)
        {
            var (report, error) = DeliveryReport.Create(
                request.id,
                request.createDate,
                request.warehouseCreatorId,
                request.fileReport
                );

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            await _service.CreateReport(report);

            return Ok(report);
        }

        /// <summary>
        /// Обновление отчета по поставке
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <param name="request">Новые данные отчета</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateReport(Guid id, [FromBody] DeliveryReportRequest request)
        {
            var reportId = await _service.UpdateReport(id,
                request.createDate,
                request.warehouseCreatorId,
                request.fileReport);

            return Ok(reportId);
        }

        /// <summary>
        /// Удаление отчета по поставке
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DeliveryReportRequest>> DeleteReport(Guid id)
        {
            return Ok(await _service.DeleteReport(id));
        }
    }
}
