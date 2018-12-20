using System;

namespace AbreVinci.Redux
{
	public delegate IObservable<IAction> Effect(IObservable<IAction> actions);
}
