using CarService.Client.ViewModels;
using InputKit.Shared.Validations;


namespace CarService.Client.Others.Validates
{
    /// <summary>
    /// Класс валидации строки где должны быть только числа при условии, что заказчик - организация
    /// </summary>
    public class OrganizationValidateOnlyDigits : BindableObject, IValidation
    {
        /// <summary>
        /// Свойство сообщения при ошибке ввода
        /// </summary>
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        /// <summary>
        /// Свойство появления сообщения об ошибке ввода
        /// </summary>
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(
            nameof(Message),
            typeof(string),
            typeof(DigitsOnlyValidation),
            "The field should contain only digits.");

        /// <summary>
        /// Свойство валидации
        /// </summary>
        /// <param name="value">значение текстового поля</param>
        /// <returns></returns>
        public bool Validate(object value)
        {
            if (value is string text)
            {
                return text.All(char.IsDigit);
            }
            CreateOrderViewModel viewModel = new CreateOrderViewModel();

            return false || viewModel.IsNaturalPerson;
        }
    }
}
