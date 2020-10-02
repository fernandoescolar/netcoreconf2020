using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Application.CommandHandlers
{
	public class CompleteCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<CompleteCommand, CommandResult>
	{
		public CompleteCommandHandler(ToDoContext context)
			: base(context)
		{
		}

		public async Task<CommandResult> Handle(CompleteCommand command, CancellationToken cancellationToken)
		{
			var task = await GetTask(command.Id);
			task.MarkComplete();
			await Context.SaveChangesAsync();
			return CommandResult.SuccessResult();
		}
	}
}
