using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
	public class EditModel : AddOrEditSingleEntityModelBase
	{
		[Required(ErrorMessage = "Please provide a description")]
		[StringLength(500, ErrorMessage = "The description cannot be longer than 500 characters")]
		public string Description { get; set; }

		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public SelectList CategoryOptions { get; set; }
	}
}
