using MediatR;

namespace TodoApp.Application.Commands
{
	public class DeleteCommand : SingleEntityCommandBase, IRequest<CommandResult>
	{
	}
}
