using TodoApp.Infrastructure.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Application.CommandHandlers
{
	public abstract class SingleTaskCommandHandlerBase : CommandHandlerBase
	{
		protected SingleTaskCommandHandlerBase(ToDoContext context)
			: base(context)
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
