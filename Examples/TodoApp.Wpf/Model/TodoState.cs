using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AbreVinci.Redux;

namespace TodoApp.Wpf.Model
{
	public class TodoState
	{
		public TodoState(IImmutableList<TodoItem> todoItems)
		{
			TodoItems = todoItems;
		}

		public IImmutableList<TodoItem> TodoItems { get; }

		public TodoState AddTodoItem(TodoItem todoItem)
		{
			return new TodoState(TodoItems.Add(todoItem));
		}

		public TodoState SetTodoItems(IEnumerable<TodoItem> todoItems)
		{
			return new TodoState(TodoItems.Clear().AddRange(todoItems));
		}

		public TodoState RemoveTodoItem(TodoItem todoItem)
		{
			return new TodoState(TodoItems.Remove(todoItem));
		}

		public TodoState ModifyTodoItem(TodoItem todoItem, Func<TodoItem, TodoItem> modify)
		{
			return new TodoState(TodoItems.SetItem(TodoItems.IndexOf(todoItem), modify(todoItem)));
		}

		public TodoState Clear()
		{
			return new TodoState(TodoItems.Clear());
		}

		public static TodoState Reducer(TodoState oldState, IAction action)
		{
			switch (action)
			{
				case TodoActions.LoadSuccessAction loadSuccessAction:
					return oldState.SetTodoItems(loadSuccessAction.Titles.Select(title => new TodoItem(title, false)));
				case TodoActions.LoadFailedAction _:
					return oldState.Clear();
				case TodoActions.AddTodo addTodo:
					return oldState.AddTodoItem(new TodoItem(addTodo.Title, false));
				case TodoActions.RemoveTodo removeTodo:
					return oldState.RemoveTodoItem(removeTodo.TodoItem);
				case TodoActions.ToggleTodoCheckedState toggleTodoCheckedState:
					return oldState.ModifyTodoItem(toggleTodoCheckedState.TodoItem, todoItem => todoItem.SetChecked(!todoItem.IsChecked));
				default:
					return oldState;
			}
		}
	}
}
