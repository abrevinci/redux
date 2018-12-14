namespace AbreVinci.Redux.Internal
{
	internal interface IStateSlice
	{
		void Dispatch(IAction action);
	}
}
