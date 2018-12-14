using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace AbreVinci.Redux.Internal
{
	internal class Store : IStore
	{
		private readonly Dictionary<string, IStateSlice> _stateSlicesByName;

		public Store()
		{
			_stateSlicesByName = new Dictionary<string, IStateSlice>();
		}

		public IObservable<TState> SelectStateSlice<TState>(string name)
		{
			return _stateSlicesByName.TryGetValue(name, out var s) && s is StateSlice<TState> stateSlice ? 
				stateSlice.State.DistinctUntilChanged().Publish() : 
				null;
		}

		public void Dispatch(IAction action)
		{
			foreach (var stateSlice in _stateSlicesByName.Values)
				stateSlice.Dispatch(action);
		}

		public void AddStateSlice<TState>(string name, TState initialState, Reducer<TState> reducer)
		{
			_stateSlicesByName.Add(name, new StateSlice<TState>(initialState, reducer));
		}

		public void RemoveStateSlice(string name)
		{
			_stateSlicesByName.Remove(name);
		}
	}
}
