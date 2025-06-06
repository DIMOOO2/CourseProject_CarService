using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace CarService.Administrator.ViewModels
{
    /// <summary>
    /// Класс модели представления страницы создания склада
    /// </summary>
    public partial class CreateWarehouseViewModel : ObservableObject
    {
        /// <summary>
        /// Новый Http-клиент
        /// </summary>
        HttpClient _httpClient = new HttpClient();
        /// <summary>
        /// Название склада
        /// </summary>
        [ObservableProperty]
        private string title;

        /// <summary>
        /// Адрес склада
        /// </summary>
        [ObservableProperty]
        private string address;

        /// <summary>
        /// Город местонахождения склада
        /// </summary>
        [ObservableProperty]
        private string city;

        /// <summary>
        /// Логин для входа в учетную запись склада
        /// </summary>
        [ObservableProperty]
        private string login;

        /// <summary>
        /// Пароль для входа в учетную запись склада
        /// </summary>
        [ObservableProperty]
        private string password;

        /// <summary>
        /// Конструктор модели представления страницы создания складов
        /// </summary>
        public CreateWarehouseViewModel()
        {
        }

        /// <summary>
        ///  Свойство хранящее успешный ответ на добавление склада
        /// </summary>
        private WarehouseResponse? _responseWarehouseTemp;

        /// <summary>
        /// Метод создания склада
        /// </summary>
        [RelayCommand]
        private async Task Create()
        {
            try
            {
                using var responseWarehouse = await _httpClient.PostAsJsonAsync<WarehouseRequest>("https://localhost:1488/Warehouse", new WarehouseRequest(Title, Address, City));
                if (responseWarehouse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _responseWarehouseTemp = await responseWarehouse.Content.ReadFromJsonAsync<WarehouseResponse>();
                    byte[] sha256Hash = GenerateSha256Hash(Password, GenerateSalt());
                    string sha256HashString = Convert.ToBase64String(sha256Hash);

                    using var responseCorporateAccount = await _httpClient.PostAsJsonAsync<CorporateAccountRequest>("https://localhost:1488/CorporateAccount", new CorporateAccountRequest(Login, sha256HashString, _responseWarehouseTemp!.Id));
                    if (responseCorporateAccount.StatusCode != System.Net.HttpStatusCode.OK)
                        throw new Exception($"Ошибка при регистрации новой учетной записи. Ошибка: {responseCorporateAccount.StatusCode}");
                    else
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Склад успешно зарегистрирован", "ОК");
                }
                else
                    throw new Exception("Ошибка при создании склада");
            }
            catch (Exception ex)
            {
                await _httpClient.DeleteFromJsonAsync<WarehouseResponse>($"https://localhost:1488/Warehouse/{_responseWarehouseTemp!.Id}");
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
