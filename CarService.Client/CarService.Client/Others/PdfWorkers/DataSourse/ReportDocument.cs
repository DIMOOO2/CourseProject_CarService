using CarService.Client.Others.Models;
using CarService.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Collections.ObjectModel;


namespace CarService.Client.Others.PdfWorkers.DataSourse
{
    /// <summary>
    /// Класс документа отчета о поступлении
    /// </summary>
    public class ReportDocument : IDocument
    {
        /// <summary>
        /// Номер отчета
        /// </summary>
        public long NumberReport { get; }

        /// <summary>
        /// Дата создания отчета
        /// </summary>
        public DateTime CreateDate { get; }

        /// <summary>
        /// Запчасти в новом поступлении
        /// </summary>
        public ObservableCollection<ArrivalAutoPart> ArrivalAutoParts { get; }

        /// <summary>
        /// Текущий склад на который пришло поступление
        /// </summary>
        public Warehouse Warehouse { get; }

        public ReportDocument(long numberReport, DateTime createDate, ObservableCollection<ArrivalAutoPart> arrivalAutoParts, Warehouse warehouse)
        {
            NumberReport = numberReport;
            CreateDate = createDate;
            ArrivalAutoParts = arrivalAutoParts;
            Warehouse = warehouse;
        }

        /// <summary>
        /// Установление стандартных метаданных
        /// </summary>
        /// <returns></returns>
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        /// <summary>
        /// Метод установления стандартных настроек при создании документа
        /// </summary>
        /// <returns></returns>
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        /// <summary>
        /// Метод создания документа
        /// </summary>
        /// <param name="container">Интерфейс контейнера документа</param>
        public void Compose(IDocumentContainer container)
        {
            container
            .Page(page =>
            {
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
        }

        /// <summary>
        /// Оформление шапки документа
        /// </summary>
        /// <param name="container">Контейнер содержиморго</param>
        void ComposeHeader(QuestPDF.Infrastructure.IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item()
                        .Text($"Отчет по поставке #{NumberReport}")
                        .FontSize(20).SemiBold().FontColor(QuestPDF.Helpers.Colors.Orange.Medium);

                    column.Item().Text(text =>
                    {
                        text.Span("Дата создания: ").SemiBold();
                        text.Span($"{CreateDate:D}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Склад: ").SemiBold();
                        text.Span($"{Warehouse.Title}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Адрес: ").SemiBold();
                        text.Span($"город {Warehouse.City} {Warehouse.Address}");
                    });
                });

                string imgPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appiconLogo.scale-400.png");

                row.ConstantItem(100).Height(100).Image(new FileStream(imgPath, FileMode.Open));
            });
        }

        /// <summary>
        /// Добавление контента
        /// </summary>
        /// <param name="container">Контейнер содержиморго</param>
        void ComposeContent(QuestPDF.Infrastructure.IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);

                column.Item().Element(ComposeTable);               
            });
        }

        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="container"></param>
        [Obsolete]
        void ComposeTable(QuestPDF.Infrastructure.IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Артикул");
                    header.Cell().Element(CellStyle).Text("Наименование");
                    header.Cell().Element(CellStyle).AlignRight().Text("Общая стоимость");
                    header.Cell().Element(CellStyle).AlignRight().Text("Количество");
                    header.Cell().Element(CellStyle).AlignRight().Text("Производитель");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Black);
                    }
                });

                foreach (var item in ArrivalAutoParts)
                {
                    table.Cell().Element(CellStyle).Text(item.AutoPart.PartNumber);
                    table.Cell().Element(CellStyle).Text(item.AutoPart.AutoPartName);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.AutoPart.Price * item.DesiredCount} ₽");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.DesiredCount);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.AutoPart.Manufacturer!.ManufacturerName}");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }
    }
}
