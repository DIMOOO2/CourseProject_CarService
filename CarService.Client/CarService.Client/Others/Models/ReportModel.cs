using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarService.Client.Others.Models
{
    public partial class ReportModel : ObservableObject
    {
        public ReportModel() { }

        public DeliveryReport DeliveryReport { get; set; }
    }
}
