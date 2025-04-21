using CarService.Client.Others.LoginData;
using CarService.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;


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
                using var response = await _httpClient.PostAsJsonAsync<CorporateAccount>("https://localhost:7196/api/accounts/signin", new CorporateAccount
                { LogIn = Login, Password = Password });
                
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    CorporateAccount? corporateAccount = await response.Content.ReadFromJsonAsync<CorporateAccount>();
                    await Application.Current!.MainPage!.DisplayAlert("Успешный ход", $"Добро пожаловать на склад {corporateAccount?.Warehouse.Title}", "ОК");
                    LoginData.SetWarehouse(corporateAccount.Warehouse);
                    App.Current.MainPage = new AppShell();
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await Application.Current!.MainPage!.DisplayAlert("Неуспешный вход", "Неправильно введен логин или пароль", "ОК");
                    Password = "";
                }
                    

            }
            catch (HttpRequestException)
            {
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", "Не удалось подключиться к серверу, проверьте подключение к интернету или попробуйте позже", "ОК");
                Password = "";
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