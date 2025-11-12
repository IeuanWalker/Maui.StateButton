using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;

public partial class TestViewModel
{
	[RelayCommand]
	static async Task Clicked()
	{
		await Alert("Clicked command", "Button clicked");
	}

	[RelayCommand]
	static async Task Pressed()
	{
		await Alert("Pressed command", "Button pressed");
	}

	[RelayCommand]
	static async Task Released()
	{
		await Alert("Released command", "Button released");
	}

	static async Task Alert(string title, string message)
	{
		Page? mainPage = Application.Current?.Windows[0].Page;
		if (mainPage is not null)
		{
			await mainPage.DisplayAlertAsync(title, message, "OK");
		}
	}
}