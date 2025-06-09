namespace CarService.Client.Others.DataServises
{
    /// <summary>
    /// Класс данных для создания отчета
    /// </summary>
    public static class ReportData
    {
        /// <summary>
        /// Путь к файлу отображения PDF
        /// </summary>
        public static string Path { get; set; } = string.Empty; 

        /// <summary>
        /// Метод установления нового пути
        /// </summary>
        /// <param name="newPath">Новый путь к файлу обзора</param>
        public static void SetPath(string newPath)
        {
            Path = newPath;
        }
    }
}
