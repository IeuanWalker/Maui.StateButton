namespace StateButton.Handler;
public partial class StateButtonHandler
{
	protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
	{
		base.CreatePlatformView();

		return new CustomContentView(VirtualView);
	}
}