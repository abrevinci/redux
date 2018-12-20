// Copyright 2018 AbreVinci Digital AB, all rights reserved

using System.Linq;
using AbreVinci.Redux;
using AbreVinci.Redux.Internal;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
	[PublicAPI]
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddReduxStore(this IServiceCollection collection)
		{
			collection.TryAddSingleton(typeof(IStore), provider => new Store(provider));

			return collection;
		}

		public static IServiceCollection AddReduxEffectsMiddleware<T>(this IServiceCollection collection) where T : class, IEffectsMiddleware
		{
			if (collection.Any(desc => desc.ServiceType == typeof(IEffectsMiddleware) || desc.ImplementationType == typeof(T)))
				return collection;

			collection.AddSingleton<IEffectsMiddleware, T>();

			return collection;
		}
	}
}
