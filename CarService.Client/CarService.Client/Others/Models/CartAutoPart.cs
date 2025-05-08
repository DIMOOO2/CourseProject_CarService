using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarService.Client.Others.Models
{
    public partial class CartAutoPart : ObservableObject
    {
        [ObservableProperty]
        private int desiredCount;

        public CartAutoPart()
        {
            DesiredCount = 1;
        }

        public AutoPart AutoPart { get; set; }


        [RelayCommand]
        private async Task AddDisiredCount()
        {
            if (AutoPart.StockAmount > DesiredCount)
                DesiredCount++;
        }

        [RelayCommand]
        private async Task DiffDisiredCount()
        {
            if (DesiredCount > 0)
                DesiredCount--;
        }
    }
}
