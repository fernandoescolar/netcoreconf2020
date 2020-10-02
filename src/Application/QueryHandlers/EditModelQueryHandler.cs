using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Queries;
using TodoApp.Infrastructure.Data;
using TodoApp.Models;

namespace TodoApp.Application.QueryHandlers
{
	public class EditModelQueryHandler : SingleTaskQueryHandlerBase, IRequestHandler<EditModelQuery, EditModel>
	{
		public EditModelQueryHandler(ToDoContext context, IMapper mapper)
			: base(context, mapper)
		{
		}

		public async Task<EditModel> Handle(EditModelQuery query, CancellationToken cancellationToken)
		{
			var model = new EditModel();
			if (query.Id > 0)
			{
				var task = await GetTask(query.Id);
				Mapper.Map(task, model);
			}

			model.CategoryOptions = new SelectList(await Context.Categories
				.OrderBy(x => x.Name)
				.ToListAsync(), "Id", "Name", model.CategoryId);

			return model;
		}
	}
}
