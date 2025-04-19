using CarService.Client.Pages;
using CarService.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async Task CreateOrder()
        {
            try
            {
                Debug.WriteLine("FormView is worked!");
                if (IsLegalEntity) 
                {
                    Models.Entities.Client newClient = new Models.Entities.Client()
                    {
                        ClientId = Guid.NewGuid(),
                        FirstName = FirstName,
                        LastName = LastName,
                        MiddleName = MiddleName,
                        PhoneNumber = PhoneNumber,
                        Email = Email,
                        Address = Address,
                        City = City,
                        Organization = new Organization()
                        {
                            OrganizationId = Guid.NewGuid(),
                            Address = Address,
                            City = City,
                            TIN = Convert.ToInt64(TinOrganization),
                            TitleOrganization = TitleOrganization
                        }
                    };

                    using var persponseClient = await client.PostAsJsonAsync<Models.Entities.Client>("https://localhost:7196/api/clients", newClient);

                    string resultClient = await persponseClient.Content.ReadAsStringAsync();
                    Debug.WriteLine(resultClient);

                    Order order = new Order() { OrderId = Guid.NewGuid(), Client = newClient, OrderDate = DateTime.Now, OrderStatus = false };

                    using var responseOrder = await client.PostAsJsonAsync<Order>("https://localhost:7196/api/orders", order);
                    //Доделать логику добавления запчастей
                }


            }
            catch (Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}