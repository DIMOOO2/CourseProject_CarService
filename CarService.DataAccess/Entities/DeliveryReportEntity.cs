namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности отчета по поставке
    /// </summary>
    public class DeliveryReportEntity
    {
        /// <summary>
        /// ID отчета
        /// </summary>
        public Guid ReportId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// ID склада-создателя
        /// </summary>
        public Guid WarehouseCreatorId { get; set; }

        /// <summary>
        /// Склад-создатель
        /// </summary>
        public WarehouseEntity? WarehouseCreator { get; set; }

        /// <summary>
        /// Файл отчета в виде массива byte
        /// </summary>
        public byte[] ReportFile { get; set; } = null!;
    }
}
