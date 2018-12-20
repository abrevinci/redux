// Copyright 2018 AbreVinci Digital AB, all rights reserved

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
			collection.TryAddSingleton<IStore, Store>();
			return collection;
		}
	}
}
