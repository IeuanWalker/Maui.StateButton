using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Microsoft.Maui.Controls.PlatformConfiguration;
using static Android.Views.View;
namespace StateButton.Behaviors;

partial class ButtonGestureBehavior
{
	Rect _rect;
	protected override void OnAttachedTo(Microsoft.Maui.Controls.View bindable, Android.Views.View platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		platformView.SetAccessibilityDelegate(new MyAccessibilityDelegate());
		platformView.Focusable = true;

		platformView.Touch += (sender, te) =>
		{
			if (sender is not Android.Views.View v)
			{
				return;
			}

			switch (te?.Event?.Action)
			{
				case MotionEventActions.Down:
					_rect = new Rect(v.Left, v.Top, v.Right, v.Bottom);

					Pressed?.Invoke(this, new EventArgs());
					break;

				case MotionEventActions.Up:
					if (_rect.Contains(v.Left + (int)te.Event.GetX(), v.Top + (int)te.Event.GetY()))
					{
						Released?.Invoke(this, new EventArgs());
						Clicked?.Invoke(this, new EventArgs());
					}
					else
					{
						Released?.Invoke(this, new EventArgs());
					}
					break;

				case MotionEventActions.Cancel:
					Released?.Invoke(this, new EventArgs());

					break;

				case MotionEventActions.Move:
					if (!_rect.Contains(v.Left + (int)te.Event.GetX(), v.Top + (int)te.Event.GetY()))
					{
						Released?.Invoke(this, new EventArgs());
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

			if (info is null)
			{
				return;
			}

			info.ClassName = "android.widget.Button";
			info.Clickable = true;
		}
	}
}