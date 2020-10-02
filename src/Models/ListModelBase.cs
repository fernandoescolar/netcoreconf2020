using System.Collections.Generic;

namespace TodoApp.Models
{
	public abstract class ListModelBase<T>
	{
		public IEnumerable<T> Items { get; set; }

		public string NotificationMessage { get; set; }

		public bool ShowNotificationMessage => !string.IsNullOrEmpty(NotificationMessage);
	}
}
