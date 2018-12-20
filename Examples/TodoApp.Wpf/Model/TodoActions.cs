using System;
using AbreVinci.Redux;

namespace TodoApp.Wpf.Model
{
	public static class TodoActions
	{
		public class Load : IAction
		{
		}

		public class LoadSuccessAction : IAction
		{
			public LoadSuccessAction(string[] titles)
			{
				Titles = titles;
			}

			public string[] Titles { get; }
		}

		public class LoadFailedAction : IAction
		{
			public LoadFailedAction(Exception exception)
			{
				Exception = exception;
			}

			public Exception Exception { get; }
		}

		public class AddTodo : IAction
		{
			public AddTodo(string title)
			{
				Title = title;
			}
			
			public string Title { get; }
		}

		public class RemoveTodo : IAction
		{
			public RemoveTodo(TodoItem todoItem)
			{
				TodoItem = todoItem;
			}
			
			public TodoItem TodoItem { get; }
		}

		public class ToggleTodoCheckedState : IAction
		{
			public ToggleTodoCheckedState(TodoItem todoItem)
			{
				TodoItem = todoItem;
			}
			
			public TodoItem TodoItem { get; }
		}
	}
}
