using CarService.Administrator.Others.Data;
using CarService.ApplicationService.Contracts.Requests;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace CarService.Administrator.ViewModels
{
    /// <summary>
    /// Класс модели представления страницы обновления склада
    /// </summary>
    public partial class UpdateWarehouseViewModel : ObservableObject
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
        /// Учетная запись привязанная к текущему складу
        /// </summary>
        private CorporateAccount CorporateAccount
        {
            get
            {
                return WebData.CorporateAccounts.FirstOrDefault(c => c.WarehouseId == AdminLocalData.CurrentWarehouse.WarehouseId)!;
            }
        }

        /// <summary>
        /// Конструктор модели представления страницы обновления склада
        /// </summary>
        public UpdateWarehouseViewModel()
        {
            Title = AdminLocalData.CurrentWarehouse.Title;
            Address = AdminLocalData.CurrentWarehouse.Address;
            City = AdminLocalData.CurrentWarehouse.City;
        }

        /// <summary>
        /// Метод обновления склада
        /// </summary>
        [RelayCommand]
        private async Task Update()
        {
            try
            {
                using var responseWarehouse = await _httpClient.PutAsJsonAsync<WarehouseRequest>($"https://localhost:1488/Warehouse/{AdminLocalData.CurrentWarehouse.WarehouseId}", new WarehouseRequest(Title, Address, City));
                if (responseWarehouse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    byte[] sha256Hash = GenerateSha256Hash(Password, GenerateSalt());
                    string sha256HashString = Convert.ToBase64String(sha256Hash);
                    using var responseCorporateAccount = await _httpClient.PutAsJsonAsync<CorporateAccountRequest>($"https://localhost:1488/CorporateAccount/{CorporateAccount.AccountId}", new CorporateAccountRequest(Login, sha256HashString, AdminLocalData.CurrentWarehouse.WarehouseId));
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
                await _httpClient.PutAsJsonAsync<WarehouseRequest>($"https://localhost:1488/Warehouse/{AdminLocalData.CurrentWarehouse.WarehouseId}", new WarehouseRequest
                (
                   AdminLocalData.CurrentWarehouse.Title,
                   AdminLocalData.CurrentWarehouse.Address,
                   AdminLocalData.CurrentWarehouse.City
                ));
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