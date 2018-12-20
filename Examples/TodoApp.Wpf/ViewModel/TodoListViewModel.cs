using System.Collections.Immutable;
using System.Linq;
using AbreVinci.Redux;
using TodoApp.Wpf.Model;
using TodoApp.Wpf.Reactive;

namespace TodoApp.Wpf.ViewModel
{
	public class TodoListViewModel
	{
		public TodoListViewModel(IStore store)
		{
			var todoItemViewModels = Selector.Create(
				store.SelectStateSlice<TodoState>("todos"),
				todoState => (IImmutableList<TodoItemViewModel>)todoState.TodoItems
					.Select(todoItem => new TodoItemViewModel(store, todoItem))
					.ToImmutableArray());
				
			TodoItems = new ReactiveImmutableList<TodoItemViewModel>(todoItemViewModels);
		}

		public ReactiveImmutableList<TodoItemViewModel> TodoItems { get; }
	}
}
