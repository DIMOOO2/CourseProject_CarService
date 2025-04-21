using CarService.Client.Others.DataServises;
using CarService.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;

namespace CarService.Client.ViewModels
{
    public partial class AutoPartForClientViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AutoPart> autoPartsWithCurrentWarehouse;

        [ObservableProperty]
        private ObservableCollection<AutoPart> autoPartsWithClient;

        [ObservableProperty]
        private bool isCollectionEmpty;

        [ObservableProperty]
        private Visibility visibilityItem;

        [ObservableProperty]
        private bool isEnabledItem;

        [ObservableProperty]
        private AutoPart selectItem;       
        
        [ObservableProperty]
        private AutoPart selectItemClient;

        [ObservableProperty]
        private int desiredCount;


        private HttpClient httpClient = new HttpClient();

        public AutoPartForClientViewModel()
        {
            IsCollectionEmpty = false;
            AutoPartsWithCurrentWarehouse = new ObservableCollection<AutoPart>();
            AutoPartsWithClient = new ObservableCollection<AutoPart>();
            UpdateCollectionLocal().GetAwaiter();
        }

        private async Task UpdateCollectionLocal()
        {
            try
            {
                ObservableCollection<AutoPart>? autoparts = WebData.AutoParts;

                if(autoparts?.Count == 0)
                {
                    IsCollectionEmpty = true;
                }
                else AutoPartsWithCurrentWarehouse = autoparts!;
            }
            catch (HttpRequestException)
            {
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", "Не удалось подключиться к серверу, проверьте подключение к интернету или попробуйте позже", "ОК");
                await Application.Current!.MainPage!.Navigation.PopAsync();
            }
        }

        [RelayCommand]
        private async Task AddToCart()
        {
            try
            {
                if (SelectItem == null) return;
                if (SelectItem.StockAmount <= 0) return;

                AutoPart? currentAutoPart = null;

                if (AutoPartsWithClient.Count != 0)
                {
                    currentAutoPart = AutoPartsWithClient.FirstOrDefault(s =>
                    s.AutoPartName == SelectItem.AutoPartName &&
                    s.PartNumber == SelectItem.PartNumber &&
                    s.AutoPartId == SelectItem.AutoPartId);
                }

                if (currentAutoPart == null)
                {
                    AutoPartsWithClient.Add(SelectItem);
                    IsEnabledItem = false;
                    VisibilityItem = Visibility.Hidden;
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }         
        }

        [RelayCommand]
        private async Task RemoveInCart()
        {
            try
            {
                if (SelectItemClient == null) return;
                AutoPartsWithClient?.Remove(SelectItemClient);
            }
            catch (Exception ex) 
            {
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }       
        }
    }
}