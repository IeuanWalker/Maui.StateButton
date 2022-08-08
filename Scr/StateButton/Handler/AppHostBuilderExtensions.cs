namespace StateButton.Handler;
public static class AppHostBuilderExtensions
{
	public static MauiAppBuilder ConfigureStateButton(this MauiAppBuilder builder)
	{
		builder
			.ConfigureMauiHandlers(handlers =>
			{
				handlers.AddTransient(typeof(StateButton), h => new StateButtonHandler());
			});

		return builder;
	}
}
