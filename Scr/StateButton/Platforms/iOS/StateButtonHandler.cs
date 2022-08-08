using Microsoft.Maui.Handlers;
using UIKit;

namespace StateButton.Handler;
public partial class StateButtonHandler : ViewHandler<IStateButton, Microsoft.Maui.Platform.ContentView>
{
	protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
	{
		return new Microsoft.Maui.Platform.ContentView();
	}

	protected override void ConnectHandler(Microsoft.Maui.Platform.ContentView platformView)
	{
		base.ConnectHandler(platformView);

		platformView.AccessibilityTraits = UIAccessibilityTrait.Button;

		platformView.AddGestureRecognizer(new UITapGestureRecognizer(() =>
		{
			// TODO: Trigger clicked
		}));
	}	
}