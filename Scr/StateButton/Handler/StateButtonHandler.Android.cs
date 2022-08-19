using Microsoft.Maui.Platform;

namespace StateButton.Handler;
public partial class StateButtonHandler
{
	protected override ContentViewGroup CreatePlatformView()
	{
		base.CreatePlatformView();

		return new CustomContentViewGroup(Context);
	}
}