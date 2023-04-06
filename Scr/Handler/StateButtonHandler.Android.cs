using IeuanWalker.Maui.StateButton.Platform;

namespace IeuanWalker.Maui.StateButton.Handler;
public partial class StateButtonHandler
{
	protected override CustomContentViewGroup CreatePlatformView()
	{
		base.CreatePlatformView();

		return new CustomContentViewGroup(Context, VirtualView);
	}
}