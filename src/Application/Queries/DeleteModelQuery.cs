using MediatR;
using TodoApp.Models;

namespace TodoApp.Application.Queries
{
	public class DeleteModelQuery : IRequest<DeleteModel>
	{
		public int Id { get; set; }
	}
}
