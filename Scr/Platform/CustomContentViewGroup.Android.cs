using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Microsoft.Maui.Platform;

namespace StateButton.Handler;
public class CustomContentViewGroup : ContentViewGroup
{
	Rect _rect;
	readonly StateButton _stateButton;
	public CustomContentViewGroup(Context context, IBorderView virtualView) : base(context)
	{
		_stateButton = (StateButton)virtualView;

		SetAccessibilityDelegate(new MyAccessibilityDelegate());
		Focusable = true;

		Touch += (sender, te) =>
		{
			if (sender is not Android.Views.View view)
			{
				return;
			}

			switch (te?.Event?.Action)
			{
				case MotionEventActions.Down:
					_rect = new Rect(view.Left, view.Top, view.Right, view.Bottom);

					_stateButton.InvokePressed();
					break;

				case MotionEventActions.Up:
					if (_rect.Contains(view.Left + (int)te.Event.GetX(), view.Top + (int)te.Event.GetY()))
					{
						_stateButton.InvokeReleased();
						_stateButton.InvokeClicked();
					}
					else
					{
						_stateButton.InvokeReleased();
					}
					break;

				case MotionEventActions.Cancel:
					_stateButton.InvokeReleased();

					break;

				case MotionEventActions.Move:
					if (!_rect.Contains(view.Left + (int)te.Event.GetX(), view.Top + (int)te.Event.GetY()))
					{
						_stateButton.InvokeReleased();
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
	public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent? e)
	{
		if (keyCode == Keycode.Space || keyCode == Keycode.Enter)
		{
			_stateButton.InvokeClicked();
			return true;
		}

		return base.OnKeyUp(keyCode, e);
	}
}