namespace App.Pages;

public partial class AccessibilityTestPage : ContentPage
{
	public AccessibilityTestPage()
	{
		InitializeComponent();
	}

	async void Button_Clicked(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Clicked", string.Empty, "OK");
	}

	async void Example6_Pressed(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Pressed", string.Empty, "OK");
	}

	async void Example6_Released(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Release", string.Empty, "OK");
	}
}