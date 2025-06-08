namespace CarService.Core.Models
{
    /// <summary>
    /// Класс отчета по поставке
    /// </summary>
    public class DeliveryReport
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="reportId">ID отчета</param>
        /// <param name="createDate">Дата создания</param>
        /// <param name="warehouseCreatorId">ID склада создателя</param>
        /// <param name="reportFile">Файл отчета</param>
        private DeliveryReport(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] reportFile)
        {
            ReportId = reportId;
            CreateDate = createDate;
            WarehouseCreatorId = warehouseCreatorId;
            ReportFile = reportFile;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public DeliveryReport() { }

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
        /// Файл отчета в виде массива byte
        /// </summary>
        public byte[] ReportFile { get; set; } = null!;

        /// <summary>
        /// Метод инициализации нового отчета по поставке
        /// </summary>
        /// <param name="reportId">ID отчета</param>
        /// <param name="createDate">Дата создания</param>
        /// <param name="warehouseCreatorId">ID склада создателя</param>
        /// <param name="reportFile">Файл отчета</param>
        /// <returns></returns>
        public static (DeliveryReport report, string error) Create(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] reportFile)
        {
            string error = string.Empty;

            if (reportId == Guid.Empty || createDate == DateTime.MinValue || warehouseCreatorId == Guid.Empty ||
                reportFile == null)
                error = "Error auto part is not created";

            DeliveryReport deliveryReport = new DeliveryReport(reportId, createDate, warehouseCreatorId, reportFile!);

            return (deliveryReport, error);
        }

        /// <summary>
        /// Получение артикула отчета
        /// </summary>
        public string GetReportArticul
        {
            get
            {
                byte[] data = ReportId.ToByteArray();
                return $"Отчет №{Convert.ToInt64(Math.Abs(BitConverter.ToInt32(data, 0)))}";
            }
        }

        /// <summary>
        /// Свойство для отображения полной даты создания отчета
        /// </summary>
        public string GetDate => $"{CreateDate:D}";
    }
}
