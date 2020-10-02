using MediatR;

namespace TodoApp.Application.Commands
{
	public class ResetCommand : SingleEntityCommandBase, IRequest<CommandResult>
	{
	}
}
