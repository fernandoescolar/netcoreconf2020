using MediatR;
using TodoApp.Models;

namespace TodoApp.Application.Queries
{
	public class IndexModelQuery : IRequest<IndexModel>
	{
		public int? CategoryId { get; set; }
	}
}
