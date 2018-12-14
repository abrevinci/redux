using JetBrains.Annotations;

namespace AbreVinci.Redux
{
	[PublicAPI]
	public delegate TState Reducer<TState>(TState oldState, IAction action);

	[PublicAPI]
	public class Reducer
	{
		public Reducer<TState> Combine<TState>(params Reducer<TState>[] reducers)
		{
			return (oldState, action) =>
			{
				var state = oldState;
				foreach (var reducer in reducers)
				{
					state = reducer(state, action);
				}
				return state;
			};
		}
	}
}
