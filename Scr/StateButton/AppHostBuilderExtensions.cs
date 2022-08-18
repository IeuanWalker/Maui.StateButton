using Microsoft.Maui.Handlers;
#if ANDROID
using StateButton.Handler;
#elif IOS
using StateButton.Handler;
#endif

namespace StateButton;

public static class AppHostBuilderExtensions
{
	public static void ConfigureStateButton()
	{
#if ANDROID
		BorderHandler.PlatformViewFactory = (handler) =>
		{
			return new CustomContentViewGroup(handler.Context); // your native view
		};

		BorderHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
		{
			if (view is StateButton stateButton)
			{
				CustomContentViewGroup platformView = (CustomContentViewGroup)handler.PlatformView;

				platformView.Pressed1 += (_, e) => stateButton.InternalPressed();
				platformView.Released += (_, e) => stateButton.InternalReleased();
				platformView.Clicked += (_, e) => stateButton.InternalClicked();
			}
		});
#elif IOS
		BorderHandler.PlatformViewFactory = (handler) =>
		{
			return new CustomContentView(); // your native view
		};

		BorderHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
		{
			if (view is StateButton stateButton)
			{
				CustomContentView platformView = (CustomContentView)handler.PlatformView;

				platformView.Pressed += (_, e) => stateButton.InternalPressed();
				platformView.Released += (_, e) => stateButton.InternalReleased();
				platformView.Clicked += (_, e) => stateButton.InternalClicked();
			}
		});
#endif
	}
}