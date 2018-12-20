using System.Collections.Immutable;
using AbreVinci.Redux;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Wpf.Model;
using TodoApp.Wpf.ViewModel;

namespace TodoApp.Wpf
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			var serviceProvider = new ServiceCollection()
				.AddReduxStore()
				.AddReduxEffectsMiddleware<TodoEffects>()
				.BuildServiceProvider();

			var store = serviceProvider.GetRequiredService<IStore>();
			store.AddStateSlice("todos", new TodoState(ImmutableArray<TodoItem>.Empty), TodoState.Reducer);

			DataContext = new MainViewModel(store);
		}
	}
}
