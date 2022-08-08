using Foundation;
using Microsoft.Maui.Handlers;
using UIKit;

namespace StateButton;

public partial class StateButtonHandler : ViewHandler<IBorderView, Microsoft.Maui.Platform.ContentView>
{
	protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
	{
		this.ContainerView?.AddGestureRecognizer(new UITapGestureRecognizer(() =>
		{
			StateButton? sharedControl = (StateButton?)VirtualView;

			if(sharedControl is null)
			{
				return;
			}

			sharedControl.ClickedGesture();
		}));

		//this.ContainerView?.TouchesMoved((NSSet touches, UIEvent? evt) =>
		//{
		//	StateButton? sharedControl = (StateButton?)VirtualView;

		//	if (sharedControl is null)
		//	{
		//		return;
		//	}

		//	sharedControl.ReleasedGesture();
		//});

		return new();
	}

	protected override void ConnectHandler(Microsoft.Maui.Platform.ContentView platformView)
	{
		base.ConnectHandler(platformView);
	}
}
