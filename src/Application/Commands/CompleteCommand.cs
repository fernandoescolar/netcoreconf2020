using MediatR;

namespace TodoApp.Application.Commands
{
	public class CompleteCommand : SingleEntityCommandBase, IRequest<CommandResult>
	{
	}
}
