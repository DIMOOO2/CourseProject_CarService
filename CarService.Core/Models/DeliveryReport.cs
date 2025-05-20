using System;

namespace CarService.Core.Models
{
    public class DeliveryReport
    {
        private DeliveryReport(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] reportFile)
        {
            ReportId = reportId;
            CreateDate = createDate;
            WarehouseCreatorId = warehouseCreatorId;
            ReportFile = reportFile;
        }

        public DeliveryReport() { }

        public Guid ReportId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid WarehouseCreatorId { get; set; }
        public byte[] ReportFile { get; set; } = null!;

        public static (DeliveryReport report, string error) Create(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] reportFile)
        {
            string error = string.Empty;

            if (reportId == Guid.Empty || createDate == DateTime.MinValue || warehouseCreatorId == Guid.Empty ||
                reportFile == null)
                error = "Error auto part is not created";

            DeliveryReport deliveryReport = new DeliveryReport(reportId, createDate, warehouseCreatorId, reportFile!);

            return (deliveryReport, error);
        }

        public long GetReportArticul
        {
            get
            {
                byte[] data = ReportId.ToByteArray();
                return Convert.ToInt64(Math.Abs(BitConverter.ToInt32(data, 0)));
            }
        }

        public string GetDate => $"{CreateDate:D}";
    }
}
