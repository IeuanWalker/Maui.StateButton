
namespace StateButton;
public partial class StateButtonHandler
{
	public static IPropertyMapper<IStateButton, StateButtonHandler> Mapper = new PropertyMapper<IStateButton, StateButtonHandler>(ViewMapper)
	{
		
	};

	public static CommandMapper<IStateButton, StateButtonHandler> CommandMapper = new(ViewCommandMapper);

	public StateButtonHandler() : base(Mapper)
	{

	}

	public StateButtonHandler(IPropertyMapper mapper) : base(mapper ?? Mapper)
	{

	}
}