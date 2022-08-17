namespace StateButton.Handler;

public static class AppHostBuilderExtensions
{
	public static void Test()
	{
		Microsoft.Maui.Handlers.BorderHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
		{
			if (view is StateButton)
			{
				#if ANDROID
				handler

				#elif IOS
						handler.PlatformView.BackgroundColor = Colors.Red.ToPlatform();
						handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.Line;
				#endif
			}
		});
	}
}