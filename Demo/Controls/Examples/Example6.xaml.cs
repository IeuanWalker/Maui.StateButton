using System.Windows.Input;

namespace App.Controls.Examples;

public partial class Example6 : ContentView
{
	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomButton), string.Empty);
	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	/// <summary>
	/// Backing BindableProperty for the <see cref="ClickedCommand"/> property.
	/// </summary>
	public static readonly BindableProperty ClickedCommandProperty = BindableProperty.Create(nameof(ClickedCommand), typeof(ICommand), typeof(Example6));

	/// <summary>
	/// Command that is triggered when the button is clicked. This is a bindable property.
	/// </summary>
	public ICommand ClickedCommand
	{
		get => (ICommand)GetValue(ClickedCommandProperty);
		set => SetValue(ClickedCommandProperty, value);
	}

	/// <summary>
	/// Backing BindableProperty for the <see cref="ClickedCommandParameter"/> property.
	/// </summary>
	public static readonly BindableProperty ClickedCommandParameterProperty = BindableProperty.Create(nameof(ClickedCommandParameter), typeof(object), typeof(Example6));

	/// <summary>
	/// Property that gets returned when  <see cref="ClickedCommand" /> is executed. This is a bindable property.
	/// </summary>
	public object ClickedCommandParameter
	{
		get => GetValue(ClickedCommandParameterProperty);
		set => SetValue(ClickedCommandParameterProperty, value);
	}

	/// <summary>
	/// Backing BindableProperty for the <see cref="PressedCommand"/> property.
	/// </summary>
	public static readonly BindableProperty PressedCommandProperty = BindableProperty.Create(nameof(PressedCommand), typeof(ICommand), typeof(Example6));

	/// <summary>
	/// Command that is triggered when the button is pressed. This is a bindable property.
	/// </summary>
	public ICommand PressedCommand
	{
		get => (ICommand)GetValue(PressedCommandProperty);
		set => SetValue(PressedCommandProperty, value);
	}

	/// <summary>
	/// Backing BindableProperty for the <see cref="PressedCommandParameter"/> property.
	/// </summary>
	public static readonly BindableProperty PressedCommandParameterProperty = BindableProperty.Create(nameof(PressedCommandParameter), typeof(object), typeof(Example6));

	/// <summary>
	/// Property that gets returned when  <see cref="PressedCommand" /> is executed. This is a bindable property.
	/// </summary>
	public object PressedCommandParameter
	{
		get => GetValue(PressedCommandParameterProperty);
		set => SetValue(PressedCommandParameterProperty, value);
	}

	/// <summary>
	/// Backing BindableProperty for the <see cref="ReleasedCommand"/> property.
	/// </summary>
	public static readonly BindableProperty ReleasedCommandProperty = BindableProperty.Create(nameof(ReleasedCommand), typeof(ICommand), typeof(Example6));

	/// <summary>
	/// Command that is triggered when the button is released. This is a bindable property.
	/// </summary>
	public ICommand ReleasedCommand
	{
		get => (ICommand)GetValue(ReleasedCommandProperty);
		set => SetValue(ReleasedCommandProperty, value);
	}

	/// <summary>
	/// Backing BindableProperty for the <see cref="ReleasedCommandParameter"/> property.
	/// </summary>
	public static readonly BindableProperty ReleasedCommandParameterProperty = BindableProperty.Create(nameof(ReleasedCommandParameter), typeof(object), typeof(Example6));

	/// <summary>
	/// Property that gets returned when  <see cref="ReleasedCommand" /> is executed. This is a bindable property.
	/// </summary>
	public object ReleasedCommandParameter
	{
		get => GetValue(ReleasedCommandParameterProperty);
		set => SetValue(ReleasedCommandParameterProperty, value);
	}

	public event EventHandler? Clicked;
	public event EventHandler? Pressed;
	public event EventHandler? Released;

	public Example6()
	{
		InitializeComponent();
	}

	void StateButton_Clicked(object sender, EventArgs e)
	{
		Clicked?.Invoke(this, EventArgs.Empty);
	}

	void StateButton_Pressed(object sender, EventArgs e)
	{
		Pressed?.Invoke(this, EventArgs.Empty);
	}

	void StateButton_Released(object sender, EventArgs e)
	{
		Released?.Invoke(this, EventArgs.Empty);
	}
}