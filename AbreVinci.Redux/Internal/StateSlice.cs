using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace AbreVinci.Redux.Internal
{
	internal class StateSlice<TState> : IStateSlice
	{
		private readonly BehaviorSubject<TState> _state;
		private readonly Reducer<TState> _reducer;

		public StateSlice(TState state, Reducer<TState> reducer)
		{
			_state = new BehaviorSubject<TState>(state);
			_reducer = reducer;
		}

		public IObservable<TState> State => _state;

		public void Dispatch(IAction action)
		{
			_state.OnNext(_reducer(_state.Value, action));
		}
	}
}
