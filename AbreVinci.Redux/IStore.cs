// Copyright 2018 AbreVinci Digital AB, all rights reserved

using System;
using JetBrains.Annotations;

namespace AbreVinci.Redux
{
	[PublicAPI]
	public interface IStore
	{
		IObservable<TState> SelectStateSlice<TState>(string name);

		void Dispatch(IAction action);
		void AddStateSlice<TState>(string name, TState initialState, Reducer<TState> reducer);
		void RemoveStateSlice(string name);
	}
}
