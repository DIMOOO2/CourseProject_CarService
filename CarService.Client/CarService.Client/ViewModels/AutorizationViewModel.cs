using CarService.Client.Others.DataServises;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
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
        private string login;

        [ObservableProperty]
        private string password;

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
                    WebData.GetAutoPartsCollection(
                        await _httpClient.GetFromJsonAsync<List<AutoPartResponse>>($"https://localhost:1488/AutoPart/fromWarehouse/{corporateAccount.warehouseId}"));
                    //WebData.GetOrdersCollection(await _httpClient.GetFromJsonAsync<ObservableCollection<Order>>("https://localhost:7196/api/orders"));
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