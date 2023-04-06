using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Java.Lang;
using Microsoft.Maui.Platform;
using String = Java.Lang.String;

namespace IeuanWalker.Maui.StateButton.Platform;
public class CustomContentViewGroup : ContentViewGroup
{
	Rect _rect;
	readonly StateButton _stateButton;
	public CustomContentViewGroup(Context context, IBorderView virtualView) : base(context)
	{
		_stateButton = (StateButton)virtualView;

		//! important - this is what makes the switch accessible via keyboard navigation
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

	public override ICharSequence? AccessibilityClassNameFormatted => new String("android.widget.Button");

	public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
	{
		if (info is not null)
		{
			info.Focusable = true;
			info.Clickable = true;
		}

		base.OnInitializeAccessibilityNodeInfo(info);
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