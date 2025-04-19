using CarService.Client.ViewModels;
using InputKit.Shared.Validations;


namespace CarService.Client.Others.Validates
{
    public class OrganizationValidateOnlyDigits : BindableObject, IValidation
    {
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly BindableProperty MessageProperty = BindableProperty.Create(
            nameof(Message),
            typeof(string),
            typeof(DigitsOnlyValidation),
            "The field should contain only digits.");

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
