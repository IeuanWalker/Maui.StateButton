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

		Focusable = true;
		Clickable = true;
	}

	public override bool OnTouchEvent(MotionEvent? e)
	{
		if(RootView is null)
		{
			return base.OnTouchEvent(e);
		}

		switch (e?.Action)
		{
			case MotionEventActions.Down:
				_rect = new Rect(RootView.Left, RootView.Top, RootView.Right, RootView.Bottom);
				_stateButton.InvokePressed();
				break;

			case MotionEventActions.Up:
				if (_rect.Contains(RootView.Left + (int)e.GetX(), RootView.Top + (int)e.GetY()))
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
				if (!_rect.Contains(RootView.Left + (int)e.GetX(), RootView.Top + (int)e.GetY()))
				{
					_stateButton.InvokeReleased();
				}

				break;
		}

		return base.OnTouchEvent(e);
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

	public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
	{
		if (info is not null)
		{
			info.Focusable = true;
			info.Clickable = true;
			info.ClassName = "android.widget.Button";
		}

		base.OnInitializeAccessibilityNodeInfo(info);
	}
}