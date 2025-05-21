using CarService.Core.Models;

namespace CarService.Administrator.Others.Data
{
    public static class AdminLocalData
    {
        public static AutoPart CurrentAutoPart { get; set; } = null!;
        public static void SetAutoPart(AutoPart temp)
        {
            CurrentAutoPart = temp;
        }
    }
}
