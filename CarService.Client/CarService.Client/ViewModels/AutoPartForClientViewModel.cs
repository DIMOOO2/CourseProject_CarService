﻿using CarService.ApplicationService.Contracts.Responses;
using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CarService.Core.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarService.Client.ViewModels
{
    /// <summary>
    /// Класс модели представления автозапчастей для клиента
    /// </summary>
    public partial class AutoPartForClientViewModel : ObservableObject
    {
        /// <summary>
        /// Список запчастей на текущем складе
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<AutoPart> autoPartsWithCurrentWarehouse = null!;

        /// <summary>
        /// Список автозапчастей для клиента
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<CartAutoPart> autoPartsWithClient = null!;

        /// <summary>
        /// Свойство, которое принимает свое значение в зависимости от пустоты списка автозапчастей на текущем складе
        /// </summary>
        [ObservableProperty]
        private bool isCollectionEmpty;

        /// <summary>
        /// Выбранный элемент запчасти из списка деталей на складе
        /// </summary>
        [ObservableProperty]
        private AutoPart selectItem = null!;       

        /// <summary>
        /// Выбранный элемент в списке автозапчастей для клиента
        /// </summary>
        [ObservableProperty]
        private CartAutoPart selectItemClient = null!;

        /// <summary>
        /// Данные автозапчасти
        /// </summary>
        public AutoPart AutoPart { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public AutoPartForClientViewModel()
        {
            try
            {
                IsCollectionEmpty = false;
                AutoPartsWithCurrentWarehouse = new ObservableCollection<AutoPart>();
                AutoPartsWithClient = new ObservableCollection<CartAutoPart>();
                if(CartData.AutoParts! != null)
                {
                    foreach (var item in CartData.AutoParts)
                    {
                        AutoPartsWithClient.Add(new CartAutoPart(item.stockAmount)
                        {
                            AutoPart = AutoPart.Create
                            (
                                item.autoPartId,
                                item.autoPartName,
                                item.partNumber,
                                item.price,
                                item.stockAmount,
                                item.manufacturerId,
                                item.warehouseId
                            ).AutoPart
                        });
                    }
                }          
                UpdateCollectionLocal().GetAwaiter();
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Обновление списка автозапчастей которые находятся на складе
        /// </summary>
        /// <returns></returns>
        private async Task UpdateCollectionLocal()
        {
            try
            {
                ObservableCollection<AutoPart>? autoparts = [.. WebData.AutoParts!.Where(a => a.WarehouseId == LoginData.CurrentWarehouse!.WarehouseId)];

                if (autoparts?.Count == 0)
                {
                    IsCollectionEmpty = true;
                }
                else
                {
                    foreach(var autoPart in autoparts!)
                    {
                        if(autoPart.StockAmount > 0)
                        {
                            autoPart.VisibilityItem = true;
                            autoPart.IsEnabledItem = true;
                        }
                    }
                    AutoPartsWithCurrentWarehouse = autoparts!;
                }
            }
            catch (HttpRequestException ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"Ошибка при подключению к серверу.\nСодержание: {ex.Message}", "ОК");
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Добаление автозапчасти в корзину заказа
        /// </summary>
        /// <returns></returns>
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
                    var current = AutoPartsWithClient.FirstOrDefault(s =>
                    s.AutoPart.AutoPartName == SelectItem.AutoPartName &&
                    s.AutoPart.PartNumber == SelectItem.PartNumber &&
                    s.AutoPart.AutoPartId == SelectItem.AutoPartId);

                    if (current != null)
                        currentAutoPart = current.AutoPart;
                }

                if (currentAutoPart == null)
                {
                    AutoPartsWithClient.Add(new CartAutoPart() { AutoPart = SelectItem, DesiredCount = 1 });
                    SelectItem.IsEnabledItem = false;
                    SelectItem.VisibilityItem = false;
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }         
        }

        /// <summary>
        /// Удаление автозапчасти из корзины
        /// </summary>
        /// <returns></returns>
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
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }       
        }

        /// <summary>
        /// Сохранение корзины
        /// </summary>
        /// <returns></returns>
        [RelayCommand] 
        private async Task SaveCart()
        {
            try
            {
                if (AutoPartsWithClient.Count == 0)
                {
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Для сохранения добавьте необходимые товары в корзину", "ОК");
                    return;
                }
                else
                {
                    ObservableCollection<AutoPartResponse> newCart = new ObservableCollection<AutoPartResponse>();

                    foreach (var item in AutoPartsWithClient)
                    {
                        newCart.Add(new AutoPartResponse(
                            item.AutoPart.AutoPartId,
                            item.AutoPart.AutoPartName,
                            item.AutoPart.PartNumber,
                            item.AutoPart.Price,
                            item.DesiredCount,
                            item.AutoPart.ManufacturerId,
                            item.AutoPart.WarehouseId));
                    }

                    CartData.SetCart(newCart);

                    await Shell.Current.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}