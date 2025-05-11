using CarService.ApplicationService.Contracts.Responses;
using System.Collections.ObjectModel;


namespace CarService.Client.Others.DataServises
{
    public static class CartData
    {
        public static ObservableCollection<AutoPartResponse>? AutoParts { get; set; }

        public static void SetCart(ObservableCollection<AutoPartResponse>? autoParts)
        {
            AutoParts = autoParts;  
        }
    }
}
