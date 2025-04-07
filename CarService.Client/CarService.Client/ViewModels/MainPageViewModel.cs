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
    bool isVisibleUpdate;

    [ObservableProperty]
    ObservableCollection<Models.Entities.Client>? clients;

    public MainPageViewModel()
    {
        UpdateRequest();
    }

    [RelayCommand]
    private async void UpdateRequest()
    {
        try
        {
            ObservableCollection<Models.Entities.Client>? collectionClient = await client.GetFromJsonAsync<ObservableCollection<Models.Entities.Client>>("https://localhost:7196/clients");
            if (collectionClient!.Count != 0)
            {
                Clients = collectionClient;
                IsVisibleItems = true;
                IsVisibleUpdate = false;
            }     
        }
        catch (HttpRequestException)
        {
            await Application.Current!.MainPage!.DisplayAlert("Ошибка", "Не удалось подключиться к серверу, проверьте подключение к интернету или попробуйте позже", "ОК");
            IsVisibleItems = false;
            IsVisibleUpdate = true;
        }   
    }
}