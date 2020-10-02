using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Mediator;

namespace TodoApp.Application.QueryHandlers
{
	public abstract class SingleTaskQueryHandlerBase : QueryHandlerBase
	{
		protected SingleTaskQueryHandlerBase(ToDoContext context, IMapper mapper)
			: base(context, mapper)
		{
		}

		protected async Task<Infrastructure.Data.Task> GetTask(int id)
		{
			var task = await Context.Tasks
				.SingleOrDefaultAsync(x => x.Id == id);
			if (task == null)
			{
				throw new NullReferenceException($"Task with id: {id} not found.");
			}

			return task;
		}
	}
}
