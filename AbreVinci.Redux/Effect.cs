// Copyright 2018 AbreVinci Digital AB, all rights reserved

using System;

namespace AbreVinci.Redux
{
	public delegate IObservable<IAction> Effect(IObservable<IAction> actions);
}
