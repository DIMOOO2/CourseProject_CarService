namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности корпоративного аккаунта
    /// </summary>
    public class CorporateAccountEntity
    {
        /// <summary>
        /// ID аккаунта
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string LogIn { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// ID склада, к которому привязан аккаунт
        /// </summary>
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// Склад, к которому привязан аккаунт
        /// </summary>
        public WarehouseEntity? Warehouse { get; set; } = null!;
    }
}
