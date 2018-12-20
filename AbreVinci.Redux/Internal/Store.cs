// Copyright 2018 AbreVinci Digital AB, all rights reserved

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.Extensions.DependencyInjection;

namespace AbreVinci.Redux.Internal
{
	internal class Store : IStore
	{
		private readonly Dictionary<string, IStateSlice> _stateSlicesByName;
		private readonly Subject<IAction> _actions;

		public Store(IServiceProvider serviceProvider)
		{
			_stateSlicesByName = new Dictionary<string, IStateSlice>();
			_actions = new Subject<IAction>();

			var allEffects = serviceProvider.GetServices<IEffectsMiddleware>().SelectMany(effects => effects.GetEffects());
			var effectObservables = allEffects.Select(effect => effect(_actions));
			var mergedEffectObservables = effectObservables.Merge();
			mergedEffectObservables.Subscribe(Dispatch);
		}

		public IObservable<TState> SelectStateSlice<TState>(string name)
		{
			return _stateSlicesByName.TryGetValue(name, out var s) && s is StateSlice<TState> stateSlice ? 
				stateSlice.State.Do(_ => {}).DistinctUntilChanged().Replay(1).RefCount() : 
				null;
		}

		public void Dispatch(IAction action)
		{
			_actions.OnNext(action);
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
