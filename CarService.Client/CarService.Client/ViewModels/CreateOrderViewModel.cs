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
    public partial class CreateOrderViewModel : ObservableObject
    {
        #region Properties
        [ObservableProperty]
        private bool isNaturalPerson;

        [ObservableProperty]
        private bool isLegalEntity;

        [ObservableProperty]
        private string firstName = null!;

        [ObservableProperty]
        private string lastName = null!;

        [ObservableProperty]
        private string middleName = null!;

        [ObservableProperty]
        private string phoneNumber = null!;

        [ObservableProperty]
        private string email = null!;

        [ObservableProperty]
        private string city = null!;

        [ObservableProperty]
        private string address = null!;

        [ObservableProperty]
        private string titleOrganization = null!;

        [ObservableProperty]
        private string tinOrganization = null!;


        #endregion
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

        private HttpClient client = new HttpClient();


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

        private bool isActiveCatch = false;
        private Guid clientGuid;
        private Guid? organizationGuid;
        private Guid orderGuid;
        private ObservableCollection<AutoPart> autoPartList = WebData.AutoParts!;
        private List<AutoPartResponse> changedAutoPart = new List<AutoPartResponse>();


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
                    if(TinOrganization.Length != 10)
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
                OrderResponse? orderResponse = await response3.Content.ReadFromJsonAsync<OrderResponse>();
                orderGuid = orderResponse!.orderId;

                List<OrderedPartRequest> orderedPartRequests = new List<OrderedPartRequest>();
                
                foreach(var item in CartData.AutoParts)
                {
                    orderedPartRequests.Add(new OrderedPartRequest(item.stockAmount, orderResponse!.orderId, item.autoPartId, LoginData.CurrentWarehouse.WarehouseId));
                }

                using var response4 = await client.PostAsJsonAsync("https://localhost:1488/OrderedPart", orderedPartRequests);
                List<OrderedPartResponse>? orderedPartResponses = await response4.Content.ReadFromJsonAsync<List<OrderedPartResponse>>();
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
                isActiveCatch = true;
            }
            finally
            {
                if (CartData.AutoParts != null)
                {
                    if (!isActiveCatch)
                    {   
                        foreach(var item in CartData.AutoParts!)
                        {
                            var autoPartChange = WebData.AutoParts!.FirstOrDefault(a => a.AutoPartId == item.autoPartId);
                            if(autoPartChange != null)
                                await client.PutAsJsonAsync<AutoPartRequest>($"https://localhost:1488/AutoPart/{autoPartChange.AutoPartId}", new AutoPartRequest(item.autoPartName,
                                    item.partNumber, item.price, autoPartChange.StockAmount - item.stockAmount, item.manufacturerId, item.warehouseId));
                        }
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", "Заказ успешно создан", "OK");
                        WebData.GetAutoPartsCollection(await client.GetFromJsonAsync<List<AutoPartResponse>>("https://localhost:1488/AutoPart/"));
                        await Shell.Current.Navigation.PopAsync();
                    }

                    else
                    {
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", "Ошибка при создании заказа", "OK");
                        await client.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Order/{orderGuid}");
                        await client.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Client/{clientGuid}");
                        await client.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Organization/{organizationGuid}");
                    }
                }        
            }
        }
    }
}