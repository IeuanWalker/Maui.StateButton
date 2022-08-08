namespace StateButton.Handler;
public static class AppHostBuilderExtensions
{
	public static MauiAppBuilder ConfigureStateButton(this MauiAppBuilder builder)
	{
		builder
			.ConfigureMauiHandlers(handlers =>
			{
				handlers.AddHandler(typeof(StateButton), typeof(StateButtonHandler));
			});

		return builder;
	}
}
