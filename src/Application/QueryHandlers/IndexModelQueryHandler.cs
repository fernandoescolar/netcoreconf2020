using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Queries;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Mediator;
using TodoApp.Models;

namespace TodoApp.Application.QueryHandlers
{
	public class IndexModelQueryHandler : QueryHandlerBase, IRequestHandler<IndexModelQuery, IndexModel>
	{
		public IndexModelQueryHandler(ToDoContext context, IMapper mapper)
			: base(context, mapper)
		{
		}

		public async Task<IndexModel> Handle(IndexModelQuery query, CancellationToken cancellationToken)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Infrastructure.Data.Task, IndexModel.TaskListEntry>();
			});

			var model = new IndexModel
			{
				CategoryId = query.CategoryId,
				Items = await Context.Tasks
					.Include(x => x.Category)
					.Where(x => !query.CategoryId.HasValue || x.Category.Id == query.CategoryId)
					.OrderBy(x => x.Description)
					.ProjectTo<IndexModel.TaskListEntry>(config)
					.ToListAsync()
			};

			model.CategoryOptions = new SelectList(await Context.Categories
				.OrderBy(x => x.Name)
				.ToListAsync(), "Id", "Name", model.CategoryId);

			return model;
		}
	}
}
