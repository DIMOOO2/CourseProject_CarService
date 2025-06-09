using InputKit.Shared.Validations;
using CarService.Client.ViewModels;

namespace CarService.Client.Others.Validates
{
    /// <summary>
    /// Класс валидации обязательного значения у строки условии, что заказчик - организация
    /// </summary>
    public class OrganizationValidateRequired : BindableObject, IValidation
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
            typeof(RequiredValidation),
            "This field is required");

        /// <summary>
        /// Свойство валидации
        /// </summary>
        /// <param name="value">значение текстового поля</param>
        /// <returns></returns>
        public bool Validate(object value)
        {
            if (value is string text)
            {
                return !string.IsNullOrEmpty(text);
            }
            CreateOrderViewModel viewModel = new CreateOrderViewModel();

            return value != null || viewModel.IsNaturalPerson;
        }
    }
}
