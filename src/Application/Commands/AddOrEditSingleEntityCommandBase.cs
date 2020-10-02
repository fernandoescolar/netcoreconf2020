namespace TodoApp.Application.Commands
{
	public abstract class AddOrEditSingleEntityCommandBase : SingleEntityCommandBase
	{
		public bool IsAdding => Id == 0;
	}
}
