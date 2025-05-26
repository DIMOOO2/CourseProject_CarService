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

        public UpdateAutoPartViewModel()
        {
            Name = AdminLocalData.CurrentAutoPart.AutoPartName;
            Price = AdminLocalData.CurrentAutoPart.Price;
            Amount = AdminLocalData.CurrentAutoPart.StockAmount;
            //ManufacturerName = AdminLocalData.CurrentManufacturer?.ManufacturerName;
           //ManufacturerEmail = AdminLocalData.CurrentManufacturer?.ContactInfo;
        }

        [RelayCommand]
        private void Update()
        {
            //логика обновления с помощью PUT-запроса
        }
    }
}
