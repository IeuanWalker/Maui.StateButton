using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace StateButton.Handler;
public class CustomContentViewGroup : ContentViewGroup
{
	Rect _rect;
	public CustomContentViewGroup(Context context) : base(context)
	{
		SetAccessibilityDelegate(new MyAccessibilityDelegate());

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

					 Pressed1?.Invoke(this, EventArgs.Empty);
					 break;

				 case MotionEventActions.Up:
					 if (_rect.Contains(view.Left + (int)te.Event.GetX(), view.Top + (int)te.Event.GetY()))
					 {
						 Released?.Invoke(this, EventArgs.Empty);
						 Clicked?.Invoke(this, EventArgs.Empty);
					 }
					 else
					 {
						 Released?.Invoke(this, EventArgs.Empty);
					 }
					 break;

				 case MotionEventActions.Cancel:
					 Released?.Invoke(this, EventArgs.Empty);

					 break;

				 case MotionEventActions.Move:
					 if (!_rect.Contains(view.Left + (int)te.Event.GetX(), view.Top + (int)te.Event.GetY()))
					 {
						 Released?.Invoke(this, EventArgs.Empty);
					 }

					 break;
			 }
		 };
	}

	public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent? e)
	{
		if (keyCode == Keycode.Space || keyCode == Keycode.Enter)
		{
			Clicked?.Invoke(this, EventArgs.Empty);
		}

		return base.OnKeyUp(keyCode, e);
	}

	public event EventHandler<EventArgs>? Clicked;
	public event EventHandler<EventArgs>? Pressed1;
	public event EventHandler<EventArgs>? Released;

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