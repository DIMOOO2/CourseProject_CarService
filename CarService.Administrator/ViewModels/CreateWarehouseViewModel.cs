using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace CarService.Administrator.ViewModels
{
    public partial class CreateWarehouseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string password;

        private HttpClient httpClient = new HttpClient();

        public CreateWarehouseViewModel()
        {
        }

        private Guid warehouseResponseTemp = Guid.Empty;
        private Guid corporateAccountResponseTemp = Guid.Empty; 
        [RelayCommand]
        private async void Create()
        {
            try
            {
                WarehouseRequest warehouseRequest = new WarehouseRequest(Title, Address, City);

                using var responseWarehouse = await httpClient.PostAsJsonAsync<WarehouseRequest>("https://localhost:1488/Warehouse", warehouseRequest);

                if(responseWarehouse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    byte[] sha256Hash = GenerateSha256Hash(Password, GenerateSalt());
                    string sha256HashString = Convert.ToBase64String(sha256Hash);
                    WarehouseResponse? warehouseResponseData = await responseWarehouse.Content.ReadFromJsonAsync<WarehouseResponse>();
                    warehouseResponseTemp = warehouseResponseData == null ? Guid.Empty : warehouseResponseData.Id;
                    CorporateAccountRequest accountRequest = new CorporateAccountRequest(Login, sha256HashString, warehouseResponseData!.Id);

                    using var responseAccount = await httpClient.PostAsJsonAsync<CorporateAccountRequest>("https://localhost:1488/CorporateAccount", accountRequest);
                    if (responseAccount.StatusCode != System.Net.HttpStatusCode.OK)
                        throw new Exception("Ошибка при регистрации аккаунта");
                    else
                    {
                        Guid corporateAccountResponseData = await responseAccount.Content.ReadFromJsonAsync<Guid>();
                        corporateAccountResponseTemp = corporateAccountResponseData; 
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Склад успешно зарегистрирован", "ОК");
                        await Shell.Current.Navigation.PopAsync();
                    }           
                }

                
            }
            catch (Exception ex)
            {
                await httpClient.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Warehouse/{warehouseResponseTemp}");
                await httpClient.DeleteFromJsonAsync<Guid>($"https://localhost:1488/CorporateAccount/{corporateAccountResponseTemp}");
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
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
