namespace CarService.Client.Pages;

public partial class AutoPartForClient : ContentPage
{
	public AutoPartForClient()
	{
		InitializeComponent();
		TestCollection.ItemsSource = new List<string>() { "wesgewrgh", "qweoihjgioweh", "qowiropweyidcbkj"};
		TestCollection1.ItemsSource = new List<string>() { "wesgewrgh", "qweoihjgioweh", "qowiropweyidcbkj"};
	}
}