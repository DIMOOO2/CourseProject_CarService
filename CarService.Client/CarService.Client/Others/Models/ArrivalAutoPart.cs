using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarService.Client.Others.Models
{
    public partial class ArrivalAutoPart : ObservableObject
    {
        [ObservableProperty]
        private uint desiredCount;

        public ArrivalAutoPart()
        {
            DesiredCount = 1;
        }

        public AutoPartInfo AutoPart { get; set; } = null!;


        [RelayCommand]
        private void AddArrivalAutoPartCount()
        {
            DesiredCount++;
        }

        [RelayCommand]
        private void DiffArrivalAutoPartCount()
        {
            if (DesiredCount > 1)
                DesiredCount--;
        }
    }
}
