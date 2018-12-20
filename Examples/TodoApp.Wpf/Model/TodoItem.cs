namespace TodoApp.Wpf.Model
{
	public class TodoItem
	{
		public TodoItem(string title, bool isChecked)
		{
			Title = title;
			IsChecked = isChecked;
		}

		public string Title { get; }
		public bool IsChecked { get; }

		public TodoItem SetChecked(bool isChecked)
		{
			return new TodoItem(Title, isChecked);
		}
	}
}
