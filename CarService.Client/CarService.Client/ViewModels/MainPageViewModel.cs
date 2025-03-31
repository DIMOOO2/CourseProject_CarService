using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CarService.Models.Entities;
using System.Collections.ObjectModel;
using System.Net.Http.Json;


namespace CarService.Client.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel() 
        {

        }
        HttpClient client = new HttpClient();

        [ObservableProperty]
        bool isNullItems;

        [ObservableProperty]
        List<Models.Entities.Client> clients;

        [RelayCommand]
        async void UpdateRequest()
        {
            //Позже изменить адрес по Docker
            await client.GetFromJsonAsync<List<Models.Entities.Client>>("https://localhost:7196/clients");
        }
    }
}
