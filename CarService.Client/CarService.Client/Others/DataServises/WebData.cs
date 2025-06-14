﻿using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using System.Collections.ObjectModel;


namespace CarService.Client.Others.DataServises
{
    /// <summary>
    /// Класс данных, которые загружаются с сервера
    /// </summary>
    public static class WebData
    {
        /// <summary>
        /// Список автозапчастей
        /// </summary>
        public static ObservableCollection<AutoPart>? AutoParts { get; set; }

        /// <summary>
        /// Список заказов
        /// </summary>
        public static ObservableCollection<Order>? Orders { get; set; }

        /// <summary>
        /// Список производителей
        /// </summary>
        public static ObservableCollection<Manufacturer>? Manufacturers { get; set; }

        /// <summary>
        /// Список клиентов
        /// </summary>
        public static ObservableCollection<Core.Models.Client>? Clients { get; set; }

        /// <summary>
        /// Список отчетов
        /// </summary>
        public static ObservableCollection<DeliveryReport>? Reports { get; set; }

        /// <summary>
        /// Метод установления нового списка автозапчастей
        /// </summary>
        /// <param name="autoParts">Новый список автомобилей</param>
        public static void GetAutoPartsCollection(List<AutoPartResponse>? autoParts)
        {
            ObservableCollection<AutoPart> currentAutoParts = new ObservableCollection<AutoPart>();
            foreach(var item in autoParts!)
            {
                currentAutoParts.Add(AutoPart.Create(item.autoPartId, item.autoPartName, item.partNumber,
                    item.price, item.stockAmount, item.manufacturerId, item.warehouseId).AutoPart);
            }

            AutoParts = currentAutoParts;
        }

        /// <summary>
        /// Метод установления нового списка заказов
        /// </summary>
        /// <param name="orders">Новый список заказов</param>
        public static void GetOrdersCollection(List<OrderResponse>? orders)
        {
            ObservableCollection<Order> currentOrders = new ObservableCollection<Order>();
            foreach (var item in orders!)
            {
                currentOrders.Add(Order.Create(item.orderId, item.orderDate, item.orderStatus, 
                    item.clientId, item.warehouseContratorId).Order);
            }

            Orders = currentOrders;
        }

        /// <summary>
        /// Метод установления нового списка клиентов
        /// </summary>
        /// <param name="clients">Новый список клиентов</param>
        public static void GetClientCollection(List<ClientResponse>? clients)
        {
            ObservableCollection<Core.Models.Client> currentClients = new ObservableCollection<Core.Models.Client>();
            foreach (var client in clients!)
            {
                currentClients.Add(Core.Models.Client.Create(client.clientId, client.firstName, client.lastName, client.middleName,
                    client.phoneNumber, client.email, client.address, client.city, client.organizationId).Client);
            }

            Clients = currentClients;
        }

        /// <summary>
        /// Метод установления нового списка производителей
        /// </summary>
        /// <param name="manufacturers">Новый список производиетелей</param>
        public static void GetCollectionManufacturer(List<ManufacturerResponse>? manufacturers)
        {
            ObservableCollection<Manufacturer> currentManufacturers = new ObservableCollection<Manufacturer>();
            foreach (var manufacturer in manufacturers!)
            {
                currentManufacturers.Add(Manufacturer.Create(manufacturer.manufacturerId, manufacturer.manufacturerName, manufacturer.contactInfo).Manufacturer);
            }

            Manufacturers = currentManufacturers;
        }

        /// <summary>
        /// Метод установления нового списка отчетов по поставкам
        /// </summary>
        /// <param name="deliveryReportResponses">Новый список отчетов</param>
        public static void GetColllectionReport(List<DeliveryReportResponse>? deliveryReportResponses)
        {
            ObservableCollection<DeliveryReport> deliveryReports = new ObservableCollection<DeliveryReport>();
            foreach(var report in deliveryReportResponses!)
            {
                deliveryReports.Add(DeliveryReport.Create(report.reportId, report.createDate, report.warehouseCreatorId, report.fileReport).report);
            }

            Reports = deliveryReports;
        }
    }
}