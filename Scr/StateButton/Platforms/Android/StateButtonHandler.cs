using Android.Views;
using Android.Views.Accessibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using static Android.Views.View;

namespace StateButton.Handler;
public partial class StateButtonHandler : ViewHandler<IStateButton, ContentViewGroup>
{
	protected override ContentViewGroup CreatePlatformView()
	{
		return new ContentViewGroup(Context);
	}

	Rect _rect;
	protected override void ConnectHandler(ContentViewGroup platformView)
	{
		base.ConnectHandler(platformView);

		platformView.SetAccessibilityDelegate(new MyAccessibilityDelegate());

		platformView.Touch += (sender, te) =>
		{
			Android.Views.View? v = sender as Android.Views.View;
			StateButton? sharedControl = sender as StateButton;

			if (v is null || sharedControl is null)
			{
				return;
			}

			switch (te?.Event?.Action)
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
					if (!_rect.Contains(v.Left + (int)te.Event.GetX(), v.Top + (int)te.Event.GetY()))
					{
						sharedControl.ReleasedGesture();
					}

					break;
			}
		};
	}

	class MyAccessibilityDelegate : AccessibilityDelegate
	{
		public override void OnInitializeAccessibilityNodeInfo(Android.Views.View? host, AccessibilityNodeInfo? info)
		{
			base.OnInitializeAccessibilityNodeInfo(host, info);

			if(info is null)
			{
				return;
			}
			
			info.ClassName = "android.widget.Button";
			info.Clickable = true;
		}
	}
}
