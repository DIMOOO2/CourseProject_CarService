using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarService.Client.Others.Models
{
    public partial class CartAutoPart : ObservableObject
    {
        [ObservableProperty]
        private uint desiredCount;

        public CartAutoPart(uint countWithFutureOrder = 1)
        {
            DesiredCount = countWithFutureOrder;
        }

        public AutoPart AutoPart { get; set; } = null!;


        [RelayCommand]
        private void AddDisiredCount()
        {
            if (AutoPart.StockAmount > DesiredCount)
                DesiredCount++;
        }

        [RelayCommand]
        private void DiffDisiredCount()
        {
            if (DesiredCount > 1)
                DesiredCount--;
        }
    }
}
