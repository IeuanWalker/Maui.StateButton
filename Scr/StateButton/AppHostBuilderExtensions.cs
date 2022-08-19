using StateButton.Handler;

namespace StateButton;

public static partial class AppHostBuilderExtensions
{
	public static void ConfigureStateButton(this MauiAppBuilder builder)
	{
		builder.ConfigureMauiHandlers(h => h.AddHandler<StateButton, StateButtonHandler>());

#if ANDROID
		StateButtonHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
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
		StateButtonHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
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