using Foundation;
using UIKit;

namespace StateButton.Handler;

public class CustomContentView : Microsoft.Maui.Platform.ContentView
{
	public event EventHandler<EventArgs>? Released;
	public event EventHandler<EventArgs>? Pressed;
	public event EventHandler<EventArgs>? Clicked;

	public CustomContentView()
	{
		AccessibilityTraits = UIAccessibilityTrait.Button;

		AddGestureRecognizer(new UITapGestureRecognizer(() => Clicked?.Invoke(this, EventArgs.Empty)));
	}
	
	public override void TouchesMoved(NSSet touches, UIEvent? evt)
	{
		Released?.Invoke(this, EventArgs.Empty);

		base.TouchesMoved(touches, evt);
	}

	public override void TouchesBegan(NSSet touches, UIEvent? evt)
	{
		Pressed?.Invoke(this, EventArgs.Empty);

		base.TouchesBegan(touches, evt);
	}

	public override void TouchesCancelled(NSSet touches, UIEvent? evt)
	{
		Released?.Invoke(this, EventArgs.Empty);

		base.TouchesCancelled(touches, evt);
	}
}