using System.Reactive.Concurrency;
using System.Threading;

namespace TodoApp.Wpf.Reactive
{
	public static class UIScheduler
	{
		public static readonly SynchronizationContextScheduler Default =
			new SynchronizationContextScheduler(SynchronizationContext.Current);
	}
}
