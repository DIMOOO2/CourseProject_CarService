using CarService.Client.Others.DataServises;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CarService.Core.Models;
using CarService.Client.Others.Models;
using CommunityToolkit.Maui.Core.Extensions;


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
        string userRequest;

        [ObservableProperty]
        ObservableCollection<AutoPartInfo>? autoParts;


        public SearchAutoPartViewModel() 
        {
            try
            {
                UpdateRequest();
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async void UpdateRequest()
        {
            try
            {
                UpdateCollection();
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
                IsVisibleItems = false;
                IsVisibleNotFoundView = true;
            }
        }

        [RelayCommand]
        private async void Search()
        {
            try
            {
                UpdateCollection();
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        private void UpdateCollection()
        {
            try
            {
                ObservableCollection<AutoPart>? collectionAutoPart = WebData.AllAutoParts;
                if (collectionAutoPart!.Count != 0)
                {
                    ObservableCollection<AutoPartInfo>? current = new ObservableCollection<AutoPartInfo>();

                    if (string.IsNullOrEmpty(UserRequest))
                    {
                        foreach (var item in collectionAutoPart)
                        {
                            current.Add(new AutoPartInfo(item.AutoPartId, item.AutoPartName, item.PartNumber,
                                item.Price, item.StockAmount, item.ManufacturerId, item.WarehouseId));
                        }
                    }

                    else
                    {
                        foreach (var item in collectionAutoPart)
                        {
                            if (item.AutoPartName.Contains(UserRequest))
                            {
                                current.Add(new AutoPartInfo(item.AutoPartId, item.AutoPartName, item.PartNumber,
                                item.Price, item.StockAmount, item.ManufacturerId, item.WarehouseId));
                            }
                        }
                    }

                    if (current.Count == 0)
                    {
                        IsVisibleItems = false;
                        IsVisibleNotFoundView = true;
                    }
                    else
                    {
                        IsVisibleItems = true;
                        IsVisibleNotFoundView = false;
                    }

                    AutoParts = current.OrderBy(m => m.GetNameManufacturer).OrderByDescending(sa => sa.GetOpacity).ToObservableCollection();
                }
                else
                {
                    IsVisibleItems = false;
                    IsVisibleNotFoundView = true;
                }
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
