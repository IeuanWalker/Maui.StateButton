using System.Windows.Input;

namespace DemoApp.ViewModels;

public class TestViewModel
{
	public ICommand ClickedCommand => new Command(async _ => await Alert("Clicked command", "Button clicked"));
	public ICommand PressedCommand => new Command(async _ => await Alert("Pressed command", "Button pressed"));
	public ICommand ReleasedCommand => new Command(async _ => await Alert("Released command", "Released released"));

	static async Task Alert(string title, string message)
	{
		Page? mainpage = Application.Current?.MainPage;
		if (mainpage is not null)
		{
			await mainpage.DisplayAlert(title, message, "Ok");
		}
	}
}