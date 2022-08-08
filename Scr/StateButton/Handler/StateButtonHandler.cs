namespace StateButton.Handler;
public partial class StateButtonHandler
{
	public static IPropertyMapper<IStateButton, StateButtonHandler> Mapper = new PropertyMapper<IStateButton, StateButtonHandler>(ViewMapper)
	{

	};

	public StateButtonHandler() : base(Mapper)
	{

	}

	public StateButtonHandler(IPropertyMapper mapper) : base(mapper ?? Mapper)
	{

	}
}