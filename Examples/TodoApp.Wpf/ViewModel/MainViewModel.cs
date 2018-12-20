using System.Reactive.Linq;
using AbreVinci.Redux;
using Reactive.Bindings;
using TodoApp.Wpf.Model;

namespace TodoApp.Wpf.ViewModel
{
	public class MainViewModel
	{
		public MainViewModel(IStore store)
		{
			NewTodoTitle = new ReactiveProperty<string>(string.Empty);

			TodoList = new TodoListViewModel(store);

			var canExecuteAddTodo = NewTodoTitle.Select(title => !string.IsNullOrWhiteSpace(title));
			AddTodo = canExecuteAddTodo.ToReactiveCommand();
			AddTodo.Subscribe(() =>
			{
				store.Dispatch(new TodoActions.AddTodo(NewTodoTitle.Value));
				NewTodoTitle.Value = string.Empty;
			});

			store.Dispatch(new TodoActions.Load());
		}

		public ReactiveProperty<string> NewTodoTitle { get; }
		public TodoListViewModel TodoList { get; }

		public ReactiveCommand AddTodo { get; }
	}
}
