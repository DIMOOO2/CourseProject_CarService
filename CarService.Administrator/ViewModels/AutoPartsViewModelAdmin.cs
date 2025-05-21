using CarService.Administrator.Others.Data;
using CarService.Administrator.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarService.Administrator.ViewModels
{
    public partial class AutoPartsViewModelAdmin : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AutoPart> autoParts;

        [ObservableProperty]
        private AutoPart selectedAutoPart;

        public AutoPartsViewModelAdmin()
        {
            AutoParts = new ObservableCollection<AutoPart>();
            AutoParts.Add(AutoPart.Create(Guid.NewGuid(), "Test", 2, 18.00M, 7, Guid.NewGuid(), Guid.NewGuid()).AutoPart);
        }

        [RelayCommand]
        private void RemoveItem()
        {
            if (SelectedAutoPart != null)
                AutoParts.Remove(SelectedAutoPart);

            else return;
        }

        [RelayCommand]
        private void UpdateItem()
        {
            AdminLocalData.SetAutoPart(SelectedAutoPart);
            Shell.Current.GoToAsync(nameof(UpdateAutoPartPage));
        }

        [RelayCommand]
        private void CreateItem()
        {
            Shell.Current.GoToAsync(nameof(CreateAutoPartPage));
        }
    }
}