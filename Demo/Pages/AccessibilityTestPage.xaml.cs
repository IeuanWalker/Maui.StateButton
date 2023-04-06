namespace App.Pages;

public partial class AccessibilityTestPage : ContentPage
{
	public AccessibilityTestPage()
	{
		InitializeComponent();
	}

	async void StateButton_Clicked(object sender, EventArgs e)
	{
		await DisplayAlert("Clicked", string.Empty, "OK");
	}

	async void StateButton_Released(object sender, EventArgs e)
	{
		await DisplayAlert("Release", string.Empty, "OK");
	}
}