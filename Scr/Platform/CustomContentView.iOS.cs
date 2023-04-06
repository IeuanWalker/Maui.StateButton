using Foundation;
using UIKit;

namespace IeuanWalker.Maui.StateButton.Platform;

public class CustomContentView : Microsoft.Maui.Platform.ContentView
{
	readonly StateButton _stateButton;
	public CustomContentView(IBorderView virtualView)
	{
		AccessibilityTraits = UIAccessibilityTrait.Button;

		_stateButton = (StateButton)virtualView;

		AddGestureRecognizer(new UITapGestureRecognizer(_stateButton.InvokeClicked));
	}

	public override bool CanBecomeFocused => true;

	public override void TouchesMoved(NSSet touches, UIEvent? evt)
	{
		_stateButton.InvokeReleased();

		base.TouchesMoved(touches, evt);
	}

	public override void TouchesBegan(NSSet touches, UIEvent? evt)
	{
		_stateButton.InvokePressed();

		base.TouchesBegan(touches, evt);
	}

	public override void TouchesCancelled(NSSet touches, UIEvent? evt)
	{
		_stateButton.InvokeReleased();

		base.TouchesCancelled(touches, evt);
	}
}