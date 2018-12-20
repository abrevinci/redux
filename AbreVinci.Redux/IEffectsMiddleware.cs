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
