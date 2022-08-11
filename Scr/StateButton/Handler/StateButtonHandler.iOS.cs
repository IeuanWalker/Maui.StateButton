using Foundation;
using Microsoft.Maui.Handlers;
using UIKit;

namespace StateButton.Handler;
public partial class StateButtonHandler : ViewHandler<IStateButton, CustomContentViewGroup>
{
	protected override CustomContentViewGroup CreatePlatformView()
	{
		return new CustomContentViewGroup();
	}

	protected override void ConnectHandler(CustomContentViewGroup platformView)
	{
		platformView.AccessibilityTraits = UIAccessibilityTrait.Button;

		platformView.AddGestureRecognizer(new UITapGestureRecognizer(() => VirtualView.InternalClicked()));

		platformView.Released += (object? _, EventArgs e) => VirtualView.InternalReleased();
		platformView.Pressed += (object? _, EventArgs e) => VirtualView.InternalPressed();

		base.ConnectHandler(platformView);
	}
}

public class CustomContentViewGroup : Microsoft.Maui.Platform.ContentView
{
	public event EventHandler<EventArgs>? Released;
	public event EventHandler<EventArgs>? Pressed;

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