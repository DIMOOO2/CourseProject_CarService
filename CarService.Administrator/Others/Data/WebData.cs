using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using System.Collections.ObjectModel;


namespace CarService.Administrator.Others.Data
{
    /// <summary>
    /// Класс данных, который используется для извлечения данных, загруженных из Web-сервера
    /// </summary>
    public static class WebData
    {
        /// <summary>
        /// Список автозачастей
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
        /// Список складов
        /// </summary>
        public static ObservableCollection<Warehouse>? Warehouses { get; set; }

        /// <summary>
        /// Метод инициализации новой коллекции автозачастей
        /// </summary>
        /// <param name="autoParts">новый список автозачастей</param>
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
        /// Метод инициализации новой коллекции заказов
        /// </summary>
        /// <param name="orders">новый список заказов</param>
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
        /// Метод инициализации новой коллекции клиентов
        /// </summary>
        /// <param name="clients">новый список клиентов</param>
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
        /// Метод инициализации новой коллекции производителей
        /// </summary>
        /// <param name="manufacturers">новый список производитилей</param>
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
        /// Метод инициализации новой коллекции складов
        /// </summary>
        /// <param name="warehouses">новый список складов</param>
        public static void GetCollectionWarehouses(List<WarehouseResponse>? warehouses)
        {
            ObservableCollection<Warehouse> currentWarehouses = new ObservableCollection<Warehouse>();
            foreach (var warehouse in warehouses!)
            {
                currentWarehouses.Add(Warehouse.Create(warehouse.Id, warehouse.Title, warehouse.Address, warehouse.City).Warehouse);
            }

            Warehouses  = currentWarehouses!;
        }
    }
}

