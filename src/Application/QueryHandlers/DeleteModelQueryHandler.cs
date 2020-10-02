using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Queries;
using TodoApp.Infrastructure.Data;
using TodoApp.Models;

namespace TodoApp.Application.QueryHandlers
{
	public class DeleteModelQueryHandler : SingleTaskQueryHandlerBase, IRequestHandler<DeleteModelQuery, DeleteModel>
	{
		public DeleteModelQueryHandler(ToDoContext context, IMapper mapper)
			: base(context, mapper)
		{
		}

		public async Task<DeleteModel> Handle(DeleteModelQuery query, CancellationToken cancellationToken)
		{
			var model = new DeleteModel();
			var task = await GetTask(query.Id);
			Mapper.Map(task, model);
			return model;
		}
	}
}
