using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CarService.Client.Others.DataServises;
using CarService.Client.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace CarService.Client.ViewModels
{
    /// <summary>
    /// Класс модели представления создания заказа
    /// </summary>
    public partial class CreateOrderViewModel : ObservableObject
    {
        #region Properties
        /// <summary>
        /// Свойство, озночающее что клиент - физическое лицо
        /// </summary>
        [ObservableProperty]
        private bool isNaturalPerson;

        /// <summary>
        /// Свойство, озночающее что клиент - юридическое лицо
        /// </summary>
        [ObservableProperty]
        private bool isLegalEntity;

        /// <summary>
        /// Имя
        /// </summary>
        [ObservableProperty]
        private string firstName = null!;

        /// <summary>
        /// Фамилия
        /// </summary>
        [ObservableProperty]
        private string lastName = null!;

        /// <summary>
        /// Отчество
        /// </summary>
        [ObservableProperty]
        private string middleName = null!;

        /// <summary>
        /// Номер телефона
        /// </summary>
        [ObservableProperty]
        private string phoneNumber = null!;

        /// <summary>
        /// Электронная почта
        /// </summary>
        [ObservableProperty]
        private string email = null!;

        /// <summary>
        /// Город местонахождения
        /// </summary>
        [ObservableProperty]
        private string city = null!;

        /// <summary>
        /// Адрес
        /// </summary>
        [ObservableProperty]
        private string address = null!;

        /// <summary>
        /// Название организации
        /// </summary>
        [ObservableProperty]
        private string titleOrganization = null!;

        /// <summary>
        /// ИНН организации
        /// </summary>
        [ObservableProperty]
        private string tinOrganization = null!;

        #endregion

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CreateOrderViewModel()
        {
            try
            {
                IsNaturalPerson = true;
                IsLegalEntity = false;
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Новый Http-клиент
        /// </summary>
        private HttpClient client = new HttpClient();

        /// <summary>
        /// Переход на страницу корзины автозапчастей для клиента
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task PushAutoPartForClient()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(AutoPartForClient));
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Свойство, показывающее состояние включения блока Catch
        /// </summary>
        private bool isActiveCatch = false;

        /// <summary>
        /// промежуточное значние ID клиента
        /// </summary>
        private Guid clientGuid;

        /// <summary>
        /// промежуточное значние ID организации
        /// </summary>
        private Guid? organizationGuid;

        /// <summary>
        /// промежуточное значние ID заказа
        /// </summary>
        private Guid orderGuid;

        /// <summary>
        /// Список автозапчастей на текущем складе
        /// </summary>
        private ObservableCollection<AutoPart> autoPartList = WebData.AutoParts!;

        /// <summary>
        /// Новый список измененных автозапчастей после оформления заказа
        /// </summary>
        private List<AutoPartResponse> changedAutoPart = new List<AutoPartResponse>();

        /// <summary>
        /// Данные заказа
        /// </summary>
        private OrderResponse? orderResponse;

        /// <summary>
        /// Метод создания заказа
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task CreateOrder()
        {
            try
            {
                if (CartData.AutoParts == null)
                {
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка создания", "Вы не добавили ни одной детали в корзину", "ОК");
                    return;
                }

                OrganizationResponose? organizationResponose = null!;

                if (IsLegalEntity)
                {
                    if (TinOrganization.Length != 10)
                    {
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка создания", "ИНН Должен содержать 10 цифр", "ОК");
                        return;
                    }

                    OrganizationRequest organizationRequest = new OrganizationRequest(TitleOrganization, Convert.ToInt64(TinOrganization), Address, City);
                    using var response1 = await client.PostAsJsonAsync<OrganizationRequest>("https://localhost:1488/Organization", organizationRequest);
                    organizationResponose = await response1.Content.ReadFromJsonAsync<OrganizationResponose>();
                    organizationGuid = organizationResponose!.organizationId;
                }

                ClientRequest clientRequest = new ClientRequest(FirstName, LastName, MiddleName, PhoneNumber, Email, Address, City, organizationResponose == null ? null : organizationResponose.organizationId);
                using var response2 = await client.PostAsJsonAsync<ClientRequest>("https://localhost:1488/Client", clientRequest);
                ClientResponse? clientResponse = await response2.Content.ReadFromJsonAsync<ClientResponse>();
                clientGuid = clientResponse!.clientId;

                OrderRequest orderRequest = new OrderRequest(DateTime.Now, false, clientResponse!.clientId, LoginData.CurrentWarehouse!.WarehouseId);
                using var response3 = await client.PostAsJsonAsync<OrderRequest>("https://localhost:1488/Order", orderRequest);
                if (response3.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Ошибка при создании заказа");
                orderResponse = await response3.Content.ReadFromJsonAsync<OrderResponse>();
                orderGuid = orderResponse!.orderId;

                List<OrderedPartRequest> orderedPartRequests = new List<OrderedPartRequest>();

                foreach (var item in CartData.AutoParts)
                {
                    orderedPartRequests.Add(new OrderedPartRequest(item.stockAmount, orderResponse!.orderId, item.autoPartId, LoginData.CurrentWarehouse.WarehouseId));
                }

                using var response4 = await client.PostAsJsonAsync("https://localhost:1488/OrderedPart", orderedPartRequests);
                List<OrderedPartResponse>? orderedPartResponses = await response4.Content.ReadFromJsonAsync<List<OrderedPartResponse>>();
            }
            catch (Exception ex)
            {
                isActiveCatch = true;
            }
            finally
            {
                if (!isActiveCatch)
                {

                    foreach (var item in CartData.AutoParts!)
                    {
                        var autoPartChange = WebData.AutoParts!.FirstOrDefault(a => a.AutoPartId == item.autoPartId);
                        if (autoPartChange != null)
                            await client.PutAsJsonAsync<AutoPartRequest>($"https://localhost:1488/AutoPart/{autoPartChange.AutoPartId}", new AutoPartRequest(item.autoPartName,
                                item.partNumber, item.price, autoPartChange.StockAmount - item.stockAmount, item.manufacturerId, item.warehouseId));
                    }
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", "Заказ успешно создан", "OK");
                    WebData.GetAutoPartsCollection(await client.GetFromJsonAsync<List<AutoPartResponse>>("https://localhost:1488/AutoPart/"));
                    WebData.GetOrdersCollection(await client.GetFromJsonAsync<List<OrderResponse>>($"https://localhost:1488/Order/fromWarehouse/{LoginData.CurrentWarehouse!.WarehouseId}"));
                    var responseNewClient = await client.GetFromJsonAsync<ClientResponse>($"https://localhost:1488/Client/{orderResponse!.clientId}");
                    if(responseNewClient != null)
                    {
                        WebData.Clients!.Add(Core.Models.Client.Create
                            (
                                responseNewClient.clientId,
                                responseNewClient.firstName,
                                responseNewClient.lastName,
                                responseNewClient.middleName,
                                responseNewClient.phoneNumber,
                                responseNewClient.email,
                                responseNewClient.address,
                                responseNewClient.city,
                                responseNewClient.organizationId
                            ).Client);
                    }
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", "Ошибка при создании заказа", "OK");
                    await client.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Order/{orderGuid}");
                    await client.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Client/{clientGuid}");
                    if(organizationGuid != null)
                        await client.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Organization/{organizationGuid}");
                }
            }
        }
    }
}