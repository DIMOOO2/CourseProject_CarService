using CarService.Administrator.Others.Data;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;

namespace CarService.Administrator.ViewModels
{
    public partial class UpdateAutoPartViewModel : ObservableObject
    {
        private HttpClient httpClient = new HttpClient();
        
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private decimal price;

        [ObservableProperty]
        private uint amount;

        [ObservableProperty]
        private string manufacturerName;

        [ObservableProperty]
        private string manufacturerEmail;

        private AutoPartRequest tempAutoPart;

        private ManufacturerRequest tempManufacturer;

        public UpdateAutoPartViewModel()
        {
            try
            {
                Name = AdminLocalData.CurrentAutoPart.AutoPartName;
                Price = AdminLocalData.CurrentAutoPart.Price;
                Amount = AdminLocalData.CurrentAutoPart.StockAmount;
                ManufacturerName = AdminLocalData.CurrentManufacturer!.ManufacturerName;
                ManufacturerEmail = AdminLocalData.CurrentManufacturer!.ContactInfo;

                tempAutoPart = new AutoPartRequest
                    (
                        Name, AdminLocalData.CurrentAutoPart.PartNumber, Price, Amount, AdminLocalData.CurrentManufacturer.ManufacturerId, Guid.Empty
                    );

                tempManufacturer = new ManufacturerRequest(ManufacturerName, ManufacturerEmail);
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }

        }

        [RelayCommand]
        private async void Update()
        {
            try
            {
                using var responseManufacturer = await httpClient.PutAsJsonAsync<ManufacturerRequest>($"https://localhost:1488/Manufacturer/{AdminLocalData.CurrentManufacturer.ManufacturerId}", new ManufacturerRequest(ManufacturerName, ManufacturerEmail));   

                if(responseManufacturer.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using var responseAutoPart = await httpClient.PutAsJsonAsync<AutoPartRequest>($"https://localhost:1488/AutoPart/{AdminLocalData.CurrentAutoPart.AutoPartId}", new AutoPartRequest
                    (
                        Name, AdminLocalData.CurrentAutoPart.PartNumber, Price, Amount, AdminLocalData.CurrentManufacturer.ManufacturerId, Guid.Empty
                    ));
                    if(responseAutoPart.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"Запчасть успешно обновлена", "ОК");
                        await Shell.Current.Navigation.PopAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
                using var responseAutoPart = await httpClient.PutAsJsonAsync<AutoPartRequest>($"https://localhost:1488/AutoPart/{AdminLocalData.CurrentAutoPart.AutoPartId}", tempAutoPart);
                using var responseManufacturer = await httpClient.PutAsJsonAsync<ManufacturerRequest>($"https://localhost:1488/Manufacturer/{AdminLocalData.CurrentManufacturer.ManufacturerId}", tempManufacturer);
            }
        }
    }
}
