using MediatR;

namespace TodoApp.Application.Commands
{
	public class AddOrEditCommand : AddOrEditSingleEntityCommandBase, IRequest<CommandResult<int>>
	{
		public string Description { get; set; }

		public int CategoryId { get; set; }
	}
}
