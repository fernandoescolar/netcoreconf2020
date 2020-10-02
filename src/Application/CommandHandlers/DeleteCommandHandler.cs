using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Application.CommandHandlers
{
	public class DeleteCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<DeleteCommand, CommandResult>
	{
		public DeleteCommandHandler(ToDoContext context)
			: base(context)
		{
		}

		public async Task<CommandResult> Handle(DeleteCommand command, CancellationToken cancellationToken)
		{
			var task = await GetTask(command.Id);
			Context.Tasks.Remove(task);
			await Context.SaveChangesAsync();
			return CommandResult.SuccessResult();
		}
	}
}
