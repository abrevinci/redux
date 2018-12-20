using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;

namespace TodoApp.Wpf.Reactive
{
	public class ReactiveImmutableList<T> : INotifyCollectionChanged, IEnumerable<T>, IObservable<IImmutableList<T>>, IDisposable
	{
		private readonly Subject<IImmutableList<T>> _source;
		private readonly IDisposable _sourceDisposable;
		private IImmutableList<T> _latestValues;

		public ReactiveImmutableList(IObservable<IImmutableList<T>> source)
		{
			_source = new Subject<IImmutableList<T>>();
			_sourceDisposable = source.Subscribe(SetValues);
			_latestValues = ImmutableArray<T>.Empty;
		}
		
		public IDisposable Subscribe(IObserver<IImmutableList<T>> observer)
		{
			return _source.Subscribe(observer);
		}

		public void Dispose()
		{
			_source.OnCompleted();
			_source.Dispose();
			_sourceDisposable.Dispose();
		}

		private void SetValues(IImmutableList<T> values)
		{
			if (_latestValues == null && values == null)
				return;
			if (_latestValues != null && values != null && _latestValues.SequenceEqual(values))
				return;

			var addedItems = values
				?.Select((value, index) => (value, index))
				?.Where(item => _latestValues == null || !_latestValues.Contains(item.value))
				?.ToList();
			var removedItems = _latestValues
				?.Select((value, index) => (value, index))
				?.Where(item => values == null || !values.Contains(item.value))
				?.Reverse()
				?.ToList();

			_latestValues = values;
			_source.OnNext(_latestValues);

			UIScheduler.Default.Schedule(
				() =>
				{
					if (removedItems != null)
					{
						foreach (var removedItem in removedItems)
						{
							CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removedItem.value, removedItem.index));
						}
					}

					if (addedItems != null)
					{
						foreach (var addedItem in addedItems)
						{
							CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, addedItem.value, addedItem.index));
						}
					}
				});
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public IEnumerator<T> GetEnumerator()
		{
			return _latestValues.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
