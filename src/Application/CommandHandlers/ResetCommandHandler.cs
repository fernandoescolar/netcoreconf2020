using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Application.CommandHandlers
{
	public class ResetCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<ResetCommand, CommandResult>
	{
		public ResetCommandHandler(ToDoContext context)
			: base(context)
		{
		}

		public async Task<CommandResult> Handle(ResetCommand command, CancellationToken cancellationToken)
		{
			var task = await GetTask(command.Id);
			task.MarkIncomplete();
			await Context.SaveChangesAsync();
			return CommandResult.SuccessResult();
		}
	}
}
