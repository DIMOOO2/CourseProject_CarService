namespace CarService.Client.Others.DataServises
{
    public static class ReportData
    {
        public static string Path { get; set; } 

        public static void SetPath(string newPath)
        {
            Path = newPath;
        }
    }
}
