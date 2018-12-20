using AbreVinci.Redux;
using Reactive.Bindings;
using TodoApp.Wpf.Model;

namespace TodoApp.Wpf.ViewModel
{
	public class TodoItemViewModel
	{
		private readonly TodoItem _todoItem;

		public TodoItemViewModel(IStore store, TodoItem todoItem)
		{
			_todoItem = todoItem;
			Title = todoItem.Title;
			IsChecked = todoItem.IsChecked;

			ToggleChecked = new ReactiveCommand();
			ToggleChecked.Subscribe(() => store.Dispatch(new TodoActions.ToggleTodoCheckedState(todoItem)));
			Delete = new ReactiveCommand();
			Delete.Subscribe(() => store.Dispatch(new TodoActions.RemoveTodo(todoItem)));
		}

		public string Title { get; }
		public bool IsChecked { get; }

		public ReactiveCommand ToggleChecked { get; }
		public ReactiveCommand Delete { get; }

		public override bool Equals(object obj)
		{
			return obj is TodoItemViewModel vm && vm._todoItem == _todoItem;
		}

		public override int GetHashCode()
		{
			return _todoItem.GetHashCode();
		}
	}
}
