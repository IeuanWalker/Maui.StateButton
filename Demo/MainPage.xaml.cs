using App.Pages;

namespace App;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	async void ExampleBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ExamplePage());
	}

	async void EventCommandBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EventCommandPage());
	}

	async void BtnNotInScrollView_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ButtonNotInScrollViewPage());
	}

	async void AccessibilityTestsBtn_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AccessibilityTestPage());
	}
}