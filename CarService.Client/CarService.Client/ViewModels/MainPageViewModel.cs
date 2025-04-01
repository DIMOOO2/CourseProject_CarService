using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace CarService.Client.ViewModels;

public partial class MainPageViewModel : ObservableObject
{       
    [ObservableProperty]
    bool? isNullItems;

    [ObservableProperty]
    ObservableCollection<Models.Entities.Client>? clients;

    HttpClient client = new HttpClient();

    [RelayCommand]
    async void UpdateRequest()
    {
        //Позже изменить адрес по Docker
        ObservableCollection<Models.Entities.Client>? clientsList = await client.GetFromJsonAsync<ObservableCollection<Models.Entities.Client>>("https://localhost:7196/clients");

        if (clientsList?.Any() == null)
        {
            isNullItems = true;
        }
        else
        {
            clients = clientsList;
            isNullItems = false;
        }
    }
}
