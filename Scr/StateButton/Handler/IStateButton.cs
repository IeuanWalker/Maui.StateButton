namespace StateButton.Handler;
public interface IStateButton : IBorderView
{
	internal void InternalClicked();
	internal void InternalPressed();
	internal void InternalReleased();
}
