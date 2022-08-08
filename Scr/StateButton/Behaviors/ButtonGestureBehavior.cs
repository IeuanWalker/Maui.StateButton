namespace StateButton.Behaviors;

partial class ButtonGestureBehavior : PlatformBehavior<View>
{
	/// <summary>
	/// Event that is triggered when button is pressed. This is a bindable property.
	/// </summary>
	public event EventHandler<EventArgs>? Pressed;

	/// <summary>
	/// Event that is triggered when button is released. This is a bindable property.
	/// </summary>
	public event EventHandler<EventArgs>? Released;

	/// <summary>
	/// Event that is triggered when button is clicked. This is a bindable property.
	/// </summary>
	public event EventHandler<EventArgs>? Clicked;
}