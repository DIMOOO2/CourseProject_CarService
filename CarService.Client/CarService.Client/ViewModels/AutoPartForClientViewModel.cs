using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CarService.Models.Entities;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarService.Client.ViewModels
{
    public partial class AutoPartForClientViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AutoPart> autoPartsWithCurrentWarehouse;

        [ObservableProperty]
        private ObservableCollection<CartAutoPart> autoPartsWithClient;

        [ObservableProperty]
        private bool isCollectionEmpty;

        [ObservableProperty]
        private Visibility visibilityItem;

        [ObservableProperty]
        private bool isEnabledItem;

        [ObservableProperty]
        private AutoPart selectItem;       
        
        [ObservableProperty]
        private CartAutoPart selectItemClient;

        private HttpClient httpClient = new HttpClient();

        public AutoPartForClientViewModel()
        {
            IsCollectionEmpty = false;
            AutoPartsWithCurrentWarehouse = new ObservableCollection<AutoPart>();
            AutoPartsWithClient = new ObservableCollection<CartAutoPart>();
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
                    s.AutoPart.AutoPartName == SelectItem.AutoPartName &&
                    s.AutoPart.PartNumber == SelectItem.PartNumber &&
                    s.AutoPart.AutoPartId == SelectItem.AutoPartId)!.AutoPart;
                }

                if (currentAutoPart == null)
                {
                    AutoPartsWithClient.Add(new CartAutoPart() { AutoPart = SelectItem, DesiredCount = 1});
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
                if (SelectItemClient == null)
                {
                    await Toast.Make("Выберете элемент, который хотите удалить", ToastDuration.Short, 14).Show();
                    return;
                }
                AutoPartsWithClient?.Remove(SelectItemClient);
            }
            catch (Exception ex) 
            {
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }       
        }

        [RelayCommand] 
        private async Task SaveCart()
        {
            if (AutoPartsWithClient.Count == 0)
            {
                await Application.Current!.MainPage!.DisplayAlert("", $"Для сохранения добавьте необходимые товары в корзину", "ОК");
                return;
            }
            else
            {
                ObservableCollection<AutoPart> newCart = new ObservableCollection<AutoPart>();

                foreach (var item in AutoPartsWithClient)
                {
                    newCart.Add(item.AutoPart);
                }

                CartData.SetCart(newCart);

                await Shell.Current.Navigation.PopAsync();
            }
        }
    }
}