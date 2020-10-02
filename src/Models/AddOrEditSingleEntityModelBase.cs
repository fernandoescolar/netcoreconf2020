namespace TodoApp.Models
{
	public abstract class AddOrEditSingleEntityModelBase : SingleEntityModelBase
	{
		public bool IsAdding => Id == 0;
	}
}
