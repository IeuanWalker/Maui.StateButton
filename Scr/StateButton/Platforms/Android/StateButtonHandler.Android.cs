using Android.Views;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace StateButton;
public partial class StateButtonHandler : BorderHandler
{
	Rect _rect;
	protected override void ConnectHandler(ContentViewGroup platformView)
	{
		base.ConnectHandler(platformView);

		platformView.Touch += (sender, te) =>
		{
			Android.Views.View? v = (Android.Views.View?)sender;
			StateButton? sharedControl = (StateButton?)VirtualView;

			if (v is null || sharedControl is null || te.Event is null)
			{
				return;
			}

			switch (te.Event.Action)
			{
				case MotionEventActions.Down:
					_rect = new Rect(v.Left, v.Top, v.Right, v.Bottom);

					sharedControl.PressedGesture();
					break;

				case MotionEventActions.Up:
					if (_rect.Contains(v.Left + (int)te.Event.GetX(), v.Top + (int)te.Event.GetY()))
					{
						sharedControl.ReleasedGesture();
						sharedControl.ClickedGesture();
					}
					else
					{
						sharedControl.ReleasedGesture();
					}
					break;

				case MotionEventActions.Cancel:
					sharedControl.ReleasedGesture();
					break;
				case MotionEventActions.Move:
					sharedControl.ReleasedGesture();
					break;
			}
		};


		base.ConnectHandler(platformView);
	}
}
