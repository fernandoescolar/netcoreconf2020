using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
	public class IndexModel : ListModelBase<IndexModel.TaskListEntry>
	{
		[Display(Name = "Category")]
		public int? CategoryId { get; set; }

		public SelectList CategoryOptions { get; set; }

		public class TaskListEntry
		{
			public int Id { get; set; }

			public string Description { get; set; }

			public bool IsComplete { get; set; }

			public string CategoryName { get; set; }
		}
	}
}
