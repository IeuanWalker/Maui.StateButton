namespace App.Controls.Examples;

public partial class Example7 : ContentView
{
	public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(CustomButton), string.Empty);
	public string Icon
	{
		get => (string)GetValue(IconProperty);
		set => SetValue(IconProperty, value);
	}

	public Example7()
	{
		InitializeComponent();
	}
}