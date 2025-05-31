using CarService.Client.Others.DataServises;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;


namespace CarService.Client.ViewModels
{
    public partial class AutorizationViewModel : ObservableObject
    {
        [ObservableProperty]
        private string login = null!;

        [ObservableProperty]
        private string password = null!;

        HttpClient _httpClient = new HttpClient();

        public AutorizationViewModel()
        {
        }

        [RelayCommand]
        private async Task LogIn()
        {
            try
            {
                if (Login == null || Password == null) return;
                byte[] sha256Hash = GenerateSha256Hash(Password, GenerateSalt());
                string sha256HashString = Convert.ToBase64String(sha256Hash);
                using var response = await _httpClient.PostAsJsonAsync<CorporateAccountRequest>("https://localhost:1488/CorporateAccount/SignIn", new CorporateAccountRequest(Login, sha256HashString, Guid.Empty));


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    CorporateAccountResponse? corporateAccount = await response.Content.ReadFromJsonAsync<CorporateAccountResponse>();
                    WarehouseRequest? warehouse = await _httpClient.GetFromJsonAsync<WarehouseRequest>($"https://localhost:1488/Warehouse/{corporateAccount!.warehouseId}");
                    LoginData.SetWarehouse(Warehouse.Create(corporateAccount.warehouseId, warehouse!.Title, warehouse.Address, warehouse.City).Warehouse);

                    var autoPartResponses = await _httpClient.GetFromJsonAsync<List<AutoPartResponse>>($"https://localhost:1488/AutoPart/fromWarehouse/{LoginData.CurrentWarehouse!.WarehouseId}");

                    WebData.GetAutoPartsCollection(autoPartResponses);
                    WebData.GetAutoAllPartsCollection(await _httpClient.GetFromJsonAsync<List<AutoPartResponse>>($"https://localhost:1488/AutoPart"));

                    List<ManufacturerResponse> manufacturerResponses = new List<ManufacturerResponse>();

                    if(autoPartResponses != null)
                    {
                        foreach(var item in autoPartResponses)
                        {
                            ManufacturerResponse? manufacturer = await _httpClient.GetFromJsonAsync<ManufacturerResponse>($"https://localhost:1488/Manufacturer/{item.manufacturerId}");
                            if(manufacturer != null)
                                manufacturerResponses.Add(manufacturer);
                        }
                    }

                    WebData.GetCollectionManufacturer(manufacturerResponses);

                    List<OrderResponse>? orderResponses = await _httpClient.GetFromJsonAsync<List<OrderResponse>>($"https://localhost:1488/Order/fromWarehouse/{corporateAccount.warehouseId}");
                    WebData.GetOrdersCollection(orderResponses);

                    List<ClientResponse> clientResponses = new List<ClientResponse>();

                    if(orderResponses != null)
                    {
                        foreach (var item in orderResponses!)
                        {
                            ClientResponse? clientResponse = await _httpClient.GetFromJsonAsync<ClientResponse>($"https://localhost:1488/Client/{item.clientId}");
                            if(clientResponse != null)
                                clientResponses.Add(clientResponse!);
                        }
                    }

                    WebData.GetClientCollection(clientResponses);

                    WebData.GetColllectionReport(await _httpClient.GetFromJsonAsync<List<DeliveryReportResponse>>($"https://localhost:1488/DeliveryReport/fromWarehouse/{corporateAccount.warehouseId}"));

                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Успешный ход", $"Добро пожаловать на склад {warehouse?.Title}", "ОК");
                    App.Current!.MainPage = new AppShell();
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Неуспешный вход", "Неправильно введен логин или пароль", "ОК");
                    Password = "";
                }
            }
            catch (HttpRequestException ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"Не удалось подключиться к серверу, проверьте подключение к интернету или попробуйте позже\nСообщение: {ex.Message}", "ОК");
                Password = "";
            }
            catch(Exception ex) 
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", ex.Message, "ОК");
            }
        }

        private static byte[] GenerateSha256Hash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            using var hash = new SHA256CryptoServiceProvider();

            return hash.ComputeHash(saltedPassword);
        }
        private static byte[] GenerateSalt()
        {
            const int SaltLength = 64;
            byte[] salt = new byte[SaltLength];

            var rngRand = new RNGCryptoServiceProvider();
            rngRand.GetBytes(salt);

            return salt;
        }
    }
}