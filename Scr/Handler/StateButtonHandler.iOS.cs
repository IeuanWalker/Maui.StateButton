using IeuanWalker.Maui.StateButton.Platform;

namespace IeuanWalker.Maui.StateButton.Handler;
public partial class StateButtonHandler
{
	protected override CustomContentView CreatePlatformView()
	{
		base.CreatePlatformView();

		return new CustomContentView(VirtualView);
	}
}