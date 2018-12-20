// Copyright 2018 AbreVinci Digital AB, all rights reserved

namespace AbreVinci.Redux.Internal
{
	internal interface IStateSlice
	{
		void Dispatch(IAction action);
	}
}
