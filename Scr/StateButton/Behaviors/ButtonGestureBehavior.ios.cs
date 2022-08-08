using UIKit;

namespace StateButton.Behaviors;
public partial class ButtonGestureBehavior
{
	protected override void OnAttachedTo(View bindable, UIView platformView)
	{
		base.OnAttachedTo(bindable, platformView);

		platformView.AccessibilityTraits = UIAccessibilityTrait.Button;

		platformView.AddGestureRecognizer(new UITapGestureRecognizer(() =>
		{
			Clicked?.Invoke(this, new EventArgs());
		}));
	}
}
