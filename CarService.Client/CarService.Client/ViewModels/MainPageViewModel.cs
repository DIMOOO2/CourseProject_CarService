using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace CarService.Client.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    HttpClient client = new HttpClient();

    [ObservableProperty]
    bool isVisibleItems;

    [ObservableProperty]
    bool isVisibleUpdate = true;

    [ObservableProperty]
    ObservableCollection<Models.Entities.Client>? clients;

    public MainPageViewModel()
    {
        UpdateRequest();
    }

    [RelayCommand]
    async void UpdateRequest()
    {
        ObservableCollection<Models.Entities.Client>? collectionClient = await client.GetFromJsonAsync<ObservableCollection<Models.Entities.Client>>("https://localhost:7196/clients");
        if (collectionClient!.Count != 0)
        {
            Clients = collectionClient;
            IsVisibleItems = true;
            IsVisibleUpdate = false;
        }
    }
}