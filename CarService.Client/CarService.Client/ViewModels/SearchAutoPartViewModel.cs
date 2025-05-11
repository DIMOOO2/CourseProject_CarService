using CarService.Client.Others.DataServises;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CarService.Core.Models;


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
        ObservableCollection<AutoPart>? autoParts;

        public SearchAutoPartViewModel() 
        {
            UpdateRequest();
        }

        [RelayCommand]
        private async void UpdateRequest()
        {
            try
            {
                ObservableCollection<AutoPart>? collectionAutoPart = WebData.AutoParts;
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
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
                IsVisibleItems = false;
                IsVisibleNotFoundView = true;
            }
        }
    }
}
