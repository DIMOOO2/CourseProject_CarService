using CarService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
