using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;

namespace CarService.Administrator.ViewModels
{
    public partial class CreateAutoPartViewModel : ObservableObject
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

        public CreateAutoPartViewModel()
        {
        }

        private ManufacturerResponse? tempManufacturer;


        [RelayCommand]
        private async void CreateAutoPart()
        {
            try
            {
                var manufacturerRequest = new ManufacturerRequest(ManufacturerName, ManufacturerEmail);
                using var response = await httpClient.PostAsJsonAsync<ManufacturerRequest>("https://localhost:1488/Manufacturer", manufacturerRequest);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    tempManufacturer = await response.Content.ReadFromJsonAsync<ManufacturerResponse>();

                    var autoPartRequest = new AutoPartRequest(Name, 0, Price, Amount, tempManufacturer!.manufacturerId, Guid.Empty);

                    using var responseAutoPart = await httpClient.PostAsJsonAsync<AutoPartRequest>("https://localhost:1488/Manufacturer", autoPartRequest);

                    if (responseAutoPart.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        AutoPartResponse? autoPartResponse = await responseAutoPart.Content.ReadFromJsonAsync<AutoPartResponse>();
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Запчасть зарегистрирована, артикул {autoPartResponse!.partNumber}", "ОК");
                        await Shell.Current.Navigation.PopAsync();
                    }

                    else
                    {
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Запчасть зарегистрировать не удалось. Код ошибки {responseAutoPart.StatusCode}", "ОК");
                        await httpClient.DeleteFromJsonAsync<ManufacturerRequest>($"https://localhost:1488/Manufacturer/{tempManufacturer!.manufacturerId}");
                    }
                }
                else
                    throw new Exception("Ошибка при создании склада");
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", ex.Message, "ОК");
            }  
        }
    }
}
