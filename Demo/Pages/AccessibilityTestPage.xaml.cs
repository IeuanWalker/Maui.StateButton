namespace App.Pages;

public partial class AccessibilityTestPage : ContentPage
{
	public AccessibilityTestPage()
	{
		InitializeComponent();
	}

	async void Button_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("Clicked", string.Empty, "OK");
	}

	async void Example6_Pressed(object sender, EventArgs e)
	{
		await DisplayAlert("Pressed", string.Empty, "OK");
	}

	async void Example6_Released(object sender, EventArgs e)
	{
		await DisplayAlert("Release", string.Empty, "OK");
	}
}