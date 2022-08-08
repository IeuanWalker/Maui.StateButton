using Microsoft.Maui.Handlers;

namespace StateButton;

public partial class StateButtonHandler : ViewHandler<IStateButton, object>
{
	protected override object CreatePlatformView() => throw new NotImplementedException();
}