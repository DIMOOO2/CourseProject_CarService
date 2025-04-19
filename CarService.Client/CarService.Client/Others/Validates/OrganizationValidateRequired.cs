using InputKit.Shared.Validations;
using CarService.Client.ViewModels;

namespace CarService.Client.Others.Validates
{
    public class OrganizationValidateRequired : BindableObject, IValidation
    {
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly BindableProperty MessageProperty = BindableProperty.Create(
            nameof(Message),
            typeof(string),
            typeof(RequiredValidation),
            "This field is required");

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
