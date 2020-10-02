using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Application.CommandHandlers
{
	public class AddOrEditCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<AddOrEditCommand, CommandResult<int>>
	{
		public AddOrEditCommandHandler(ToDoContext context)
			: base(context)
		{
		}

		public async Task<CommandResult<int>> Handle(AddOrEditCommand command, CancellationToken cancellationToken)
		{
			var category = await GetCategory(command.CategoryId);
			Infrastructure.Data.Task task;
			if (command.IsAdding)
			{
				task = new Infrastructure.Data.Task(command.Description, category);
				Context.Tasks.Add(task);
			}
			else
			{
				task = await GetTask(command.Id);
				task.SetDetails(command.Description, category);
			}

			await Context.SaveChangesAsync();

			return CommandResult<int>.SuccessResult(task.Id);
		}

		private async Task<Category> GetCategory(int id)
		{
			var task = await Context.Categories
				.SingleOrDefaultAsync(x => x.Id == id);
			if (task == null)
			{
				throw new NullReferenceException($"Category with id: {id} not found.");
			}

			return task;
		}
	}
}
