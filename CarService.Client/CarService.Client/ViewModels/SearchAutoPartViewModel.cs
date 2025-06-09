using CarService.Client.Others.DataServises;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CarService.Core.Models;
using CarService.Client.Others.Models;
using CommunityToolkit.Maui.Core.Extensions;
using CarService.ApplicationService.Contracts.Responses;
using System.Net.Http.Json;


namespace CarService.Client.ViewModels
{
    /// <summary>
    /// Класс модели представления страницы поиска автозапчастей
    /// </summary>
    public partial class SearchAutoPartViewModel : ObservableObject
    {
        /// <summary>
        /// Новый Http-клиент
        /// </summary>
        HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Свойство видимости запчастей
        /// </summary>
        [ObservableProperty]
        bool isVisibleItems;

        /// <summary>
        /// Свойство видимости сообщения об ошибке нахождения данных о запчастях на складе
        /// </summary>
        [ObservableProperty]
        bool isVisibleNotFoundView;

        /// <summary>
        /// Значение поисковой строки
        /// </summary>
        [ObservableProperty]
        string userRequest;

        /// <summary>
        /// Список автозапчастей
        /// </summary>
        [ObservableProperty]
        ObservableCollection<AutoPartInfo>? autoParts;

        /// <summary>
        /// Конструктор класса
        /// </summary>
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

        /// <summary>
        /// Обновление коллекции автозапчастей
        /// </summary>
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

        /// <summary>
        /// Получение коллекции автозапчастей из сервера
        /// </summary>
        [RelayCommand]
        private async void GetCollection()
        {
            WebData.GetAutoPartsCollection(await httpClient.GetFromJsonAsync<List<AutoPartResponse>>($"https://localhost:1488/AutoPart/fromWarehouse/{LoginData.CurrentWarehouse!.WarehouseId}"));

            UpdateCollection();
        }

        /// <summary>
        /// Поиск автозапчасти исходя из поискового запроса
        /// </summary>
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

        /// <summary>
        /// Обновление коллекции, в зависимости от запроса
        /// </summary>
        private void UpdateCollection()
        {
            try
            {
                ObservableCollection<AutoPart>? collectionAutoPart = WebData.AutoParts;
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
                            if (item.AutoPartName.ToLower().StartsWith(UserRequest.ToLower()))
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
