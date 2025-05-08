using CarService.Core.Models;

using System.Collections.ObjectModel;


namespace CarService.Client.Others.DataServises
{
    public static class CartData
    {
        public static ObservableCollection<AutoPart>? AutoParts { get; set; }

        public static void SetCart(ObservableCollection<AutoPart>? autoParts)
        {
            AutoParts = autoParts;  
        }
    }
}
