// Copyright 2018 AbreVinci Digital AB, all rights reserved

using System;
using System.Reactive.Linq;
using JetBrains.Annotations;

namespace AbreVinci.Redux
{
	[PublicAPI]
	public static class Selector
	{
		public static IObservable<TOut> Create<TIn, TOut>(IObservable<TIn> s, Func<TIn, TOut> select)
		{
			return s.Select(select).DistinctUntilChanged().Replay(1).RefCount();
		}

		public static IObservable<TOut> Create<TIn1, TIn2, TOut>(IObservable<TIn1> s1, IObservable<TIn2> s2, Func<TIn1, TIn2, TOut> select)
		{
			return s1.CombineLatest(s2, select).DistinctUntilChanged().Replay(1).RefCount();
		}

		public static IObservable<TOut> Create<TIn1, TIn2, TIn3, TOut>(
			IObservable<TIn1> s1, 
			IObservable<TIn2> s2, 
			IObservable<TIn3> s3, 
			Func<TIn1, TIn2, TIn3, TOut> select)
		{
			return s1.CombineLatest(s2, s3, select).DistinctUntilChanged().Replay(1).RefCount();
		}

		public static IObservable<TOut> Create<TIn1, TIn2, TIn3, TIn4, TOut>(
			IObservable<TIn1> s1, 
			IObservable<TIn2> s2, 
			IObservable<TIn3> s3, 
			IObservable<TIn4> s4, 
			Func<TIn1, TIn2, TIn3, TIn4, TOut> select)
		{
			return s1.CombineLatest(s2, s3, s4, select).DistinctUntilChanged().Replay(1).RefCount();
		}

		public static IObservable<TOut> Create<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(
			IObservable<TIn1> s1, 
			IObservable<TIn2> s2, 
			IObservable<TIn3> s3, 
			IObservable<TIn4> s4, 
			IObservable<TIn5> s5, 
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> select)
		{
			return s1.CombineLatest(s2, s3, s4, s5, select).DistinctUntilChanged().Replay(1).RefCount();
		}

		public static IObservable<TOut> Create<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(
			IObservable<TIn1> s1, 
			IObservable<TIn2> s2, 
			IObservable<TIn3> s3, 
			IObservable<TIn4> s4, 
			IObservable<TIn5> s5, 
			IObservable<TIn6> s6,
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> select)
		{
			return s1.CombineLatest(s2, s3, s4, s5, s6, select).DistinctUntilChanged().Replay(1).RefCount();
		}

		public static IObservable<TOut> Create<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(
			IObservable<TIn1> s1, 
			IObservable<TIn2> s2, 
			IObservable<TIn3> s3, 
			IObservable<TIn4> s4, 
			IObservable<TIn5> s5, 
			IObservable<TIn6> s6, 
			IObservable<TIn7> s7, 
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> select)
		{
			return s1.CombineLatest(s2, s3, s4, s5, s6, s7, select).DistinctUntilChanged().Replay(1).RefCount();
		}

		public static IObservable<TOut> Create<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>(
			IObservable<TIn1> s1, 
			IObservable<TIn2> s2, 
			IObservable<TIn3> s3, 
			IObservable<TIn4> s4, 
			IObservable<TIn5> s5, 
			IObservable<TIn6> s6, 
			IObservable<TIn7> s7, 
			IObservable<TIn8> s8,
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut> select)
		{
			return s1.CombineLatest(s2, s3, s4, s5, s6, s7, s8, select).DistinctUntilChanged().Replay(1).RefCount();
		}
	}
}
