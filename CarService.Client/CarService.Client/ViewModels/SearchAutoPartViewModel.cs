using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;


namespace CarService.Client.ViewModels
{
    public partial class SearchAutoPartViewModel : ObservableObject
    {
        HttpClient client = new HttpClient();

        [ObservableProperty]
        bool isVisibleItems;

        [ObservableProperty]
        bool isVisibleNotFoundView;

        [ObservableProperty]
        ObservableCollection<Models.Entities.AutoPart>? autoParts;

        public SearchAutoPartViewModel() 
        {
            UpdateRequest();
        }

        [RelayCommand]
        private async void UpdateRequest()
        {
            try
            {
                ObservableCollection<Models.Entities.AutoPart>? collectionAutoPart = await client.GetFromJsonAsync<ObservableCollection<Models.Entities.AutoPart>>("https://localhost:7196/autoparts");
                if (collectionAutoPart!.Count != 0)
                {
                    AutoParts = collectionAutoPart;
                    IsVisibleItems = true;
                    IsVisibleNotFoundView = false;
                }
                else
                {
                    IsVisibleItems = false;
                    IsVisibleNotFoundView = true;
                }
            }
            catch (HttpRequestException)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", "Не удалось подключиться к серверу, проверьте подключение к интернету или попробуйте позже", "ОК");
                IsVisibleItems = false;
                IsVisibleNotFoundView = true;
            }
        }
    }
}
