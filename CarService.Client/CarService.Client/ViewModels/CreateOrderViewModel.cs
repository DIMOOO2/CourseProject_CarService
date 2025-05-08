using CarService.Client.Others.DataServises;
using CarService.Client.Pages;
using CarService.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;

namespace CarService.Client.ViewModels
{
    public partial class CreateOrderViewModel : ObservableObject
    {
        #region Properties
        [ObservableProperty]
        private bool isNaturalPerson;
        
        [ObservableProperty]
        private bool isLegalEntity;

        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string middleName;

        [ObservableProperty]
        private string phoneNumber;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string titleOrganization;

        [ObservableProperty]
        private string tinOrganization;

       
        #endregion 
        public CreateOrderViewModel()
        {
            IsNaturalPerson = true;
            IsLegalEntity = false;
        }

        private List<OrderedPart> orderedParts;
        private HttpClient client = new HttpClient();
        

        [RelayCommand]
        private async Task PushAutoPartForClient()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(AutoPartForClient));
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async Task CreateOrder()
        {
            try
            {
                if(CartData.AutoParts == null)
                {
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка создания", "Вы не добавили ни одной детали в корзину", "ОК");
                    return;
                }
                if (IsLegalEntity) 
                {
                    Models.Entities.Client newClient = new Models.Entities.Client()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        MiddleName = MiddleName,
                        PhoneNumber = PhoneNumber,
                        Email = Email,
                        Address = Address,
                        City = City,
                        Organization = new Organization()
                        {
                            Address = Address,
                            City = City,
                            TIN = Convert.ToInt64(TinOrganization),
                            TitleOrganization = TitleOrganization
                        }
                    };


                    Order order = new Order() { ArticulGuid = Guid.NewGuid(), Client = newClient, OrderDate = DateTime.Now, OrderStatus = false };

                    ObservableCollection<OrderedPart> orderedParts = new ObservableCollection<OrderedPart>();
                    OrderedPart ordered = new OrderedPart();

                    foreach(var item in CartData.AutoParts!)
                    {
                        ordered.Amount = item.StockAmount;
                        ordered.Order = order;
                        ordered.AutoPart = item;
                        //ordered.DepartureWarehouse = LoginData.CurrentWarehouse!;
                        orderedParts.Add(ordered);
                    }

                    using var persponseClient = await client.PostAsJsonAsync<Models.Entities.Client>("https://localhost:7196/api/clients", newClient);
                    using var responseOrder = await client.PostAsJsonAsync<Order>("https://localhost:7196/api/orders", order);
                    using var responseOrderedParts = await client.PostAsJsonAsync<ObservableCollection<OrderedPart>>("https://localhost:7196/api/orders", orderedParts);

                    if(persponseClient.StatusCode == System.Net.HttpStatusCode.OK
                        && responseOrder.StatusCode == System.Net.HttpStatusCode.OK
                        && responseOrderedParts.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", "Заказ оформлен", "ОК");
                        await Shell.Current.Navigation.PopAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}