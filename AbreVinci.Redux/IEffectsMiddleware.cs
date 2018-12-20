// Copyright 2018 AbreVinci Digital AB, all rights reserved

using System.Collections.Generic;
using JetBrains.Annotations;

namespace AbreVinci.Redux
{
	[PublicAPI]
	public interface IEffectsMiddleware
	{
		IEnumerable<Effect> GetEffects();
	}
}
