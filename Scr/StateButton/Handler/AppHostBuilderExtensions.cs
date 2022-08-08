namespace StateButton;

public static class AppHostBuilderExtensions
{
	public static MauiAppBuilder ConfigureCustomControls(this MauiAppBuilder builder, bool useCompatibilityRenderers = false)
	{
		builder
			.ConfigureMauiHandlers(handlers =>
			{
				handlers.AddTransient(typeof(StateButton), h => new StateButtonHandler());
			});

		return builder;
	}
}