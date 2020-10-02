using MediatR;
using TodoApp.Models;

namespace TodoApp.Application.Queries
{
	public class EditModelQuery : IRequest<EditModel>
	{
		public int Id { get; set; }
	}
}
