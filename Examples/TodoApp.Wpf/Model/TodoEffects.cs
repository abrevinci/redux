using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using AbreVinci.Redux;

namespace TodoApp.Wpf.Model
{
	public class TodoEffects : IEffectsMiddleware
	{
		public IEnumerable<Effect> GetEffects()
		{
			yield return actions => actions
				.OfType<TodoActions.Load>()
				.Select(_ => File.ReadAllLines("todos.txt"))
				.Select(lines => Observable.Return(new TodoActions.LoadSuccessAction(lines)))
				.Switch()
				.Catch<IAction, Exception>(exception => Observable.Return(new TodoActions.LoadFailedAction(exception)));
		}
	}
}
