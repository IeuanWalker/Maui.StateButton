using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using static Android.Views.View;

namespace StateButton.Handler;

public partial class StateButtonHandler : ViewHandler<IStateButton, CustomContentViewGroup>
{
	protected override CustomContentViewGroup CreatePlatformView()
	{
		return new(Context);
	}

	Rect _rect;
	protected override void ConnectHandler(CustomContentViewGroup platformView)
	{
		platformView.SetAccessibilityDelegate(new MyAccessibilityDelegate());

		platformView.Touch += (sender, te) =>
		{
			if (sender is not Android.Views.View view)
			{
				return;
			}

			switch (te?.Event?.Action)
			{
				case MotionEventActions.Down:
					_rect = new Rect(view.Left, view.Top, view.Right, view.Bottom);

					VirtualView.InternalPressed();
					break;

				case MotionEventActions.Up:
					if (_rect.Contains(view.Left + (int)te.Event.GetX(), view.Top + (int)te.Event.GetY()))
					{
						VirtualView.InternalReleased();
						VirtualView.InternalClicked();
					}
					else
					{
						VirtualView.InternalReleased();
					}
					break;

				case MotionEventActions.Cancel:
					VirtualView.InternalReleased();

					break;

				case MotionEventActions.Move:
					if (!_rect.Contains(view.Left + (int)te.Event.GetX(), view.Top + (int)te.Event.GetY()))
					{
						VirtualView.InternalReleased();
					}

					break;
			}
		};

		platformView.AccessiblityKeyboardClicked += (object? _, EventArgs e) => VirtualView.InternalClicked();

		base.ConnectHandler(platformView);
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

public class CustomContentViewGroup : ContentViewGroup
{
	public CustomContentViewGroup(Context context) : base(context)
	{
	}

	public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent? e)
	{
		if (keyCode == Keycode.Space || keyCode == Keycode.Enter)
		{
			AccessiblityKeyboardClicked?.Invoke(this, EventArgs.Empty);
		}

		return base.OnKeyUp(keyCode, e);
	}

	public event EventHandler<EventArgs>? AccessiblityKeyboardClicked;
}