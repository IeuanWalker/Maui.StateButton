namespace StateButton.Handler;

public partial class StateButtonHandler
{
	public static readonly IPropertyMapper<IStateButton, StateButtonHandler> StateButtonMapper = new PropertyMapper<IStateButton, StateButtonHandler>(ViewMapper);
	public static readonly CommandMapper<IStateButton, StateButtonHandler> StateButtonCommandMapper = new(ViewCommandMapper);

	public StateButtonHandler(IPropertyMapper? mapper, CommandMapper? commandMapper) : base(mapper ?? StateButtonMapper, commandMapper ?? StateButtonCommandMapper)
	{
	}

	public StateButtonHandler() : base(StateButtonMapper, StateButtonCommandMapper)
	{
	}
}