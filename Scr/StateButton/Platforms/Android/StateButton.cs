using Android.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;

namespace StateButton;
public partial class StateButton : Border
{

	protected override void ConnectHandler()
	{
		
	}
	Rect _rect;
	protected override void OnHandlerChanged()
	{
		base.OnHandlerChanged();

		ContentViewGroup? platformView = Handler?.PlatformView as ContentViewGroup;

		if (platformView == null)
		{
			return;
		}

		platformView.Touch += (sender, te) =>
		{
			Android.Views.View? v = (Android.Views.View?)sender;

			if (v is null || te.Event is null)
			{
				return;
			}

			switch (te.Event.Action)
			{
				case MotionEventActions.Down:
					_rect = new Rect(v.Left, v.Top, v.Right, v.Bottom);

					PressedGesture();
					break;

				case MotionEventActions.Up:
					if (_rect.Contains(v.Left + (int)te.Event.GetX(), v.Top + (int)te.Event.GetY()))
					{
						ReleasedGesture();
						ClickedGesture();
					}
					else
					{
						ReleasedGesture();
					}
					break;

				case MotionEventActions.Cancel:
					ReleasedGesture();
					break;
				case MotionEventActions.Move:
					ReleasedGesture();
					break;
			}
		};
	}	
}
