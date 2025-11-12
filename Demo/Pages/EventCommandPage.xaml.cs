namespace App.Pages;

public partial class EventCommandPage : ContentPage
{
	public EventCommandPage()
	{
		InitializeComponent();
	}

	async void StateButton_OnClicked(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Clicked event", "Button clicked", "OK");
	}

	async void StateButton_OnPressed(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Pressed event", "Button pressed", "OK");
	}

	async void StateButton_OnReleased(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Released event", "Button released", "OK");
	}

	void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	{
		Label? textExtender = sender as Label;

		if (Description.MaxLines == int.MaxValue)
		{
			Description.MaxLines = 3;
			textExtender?.Text = "See more..";
		}
		else
		{
			Description.MaxLines = int.MaxValue;
			textExtender?.Text = "See less...";
		}
	}

	async void Card_OnClicked(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Card click", string.Empty, "OK");
	}

	async void Button_OnClicked(object sender, EventArgs e)
	{
		await DisplayAlertAsync("XF button clicked", string.Empty, "OK");
	}

	async void NestButton_OnClicked(object sender, EventArgs e)
	{
		await DisplayAlertAsync("Nested state button clicked", string.Empty, "OK");
	}
}