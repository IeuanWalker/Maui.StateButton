using Microsoft.Maui.Handlers;

namespace StateButton.Handler;

public partial class StateButtonHandler : ViewHandler<IStateButton, object>
{
	protected override object CreatePlatformView() => throw new NotImplementedException();
}