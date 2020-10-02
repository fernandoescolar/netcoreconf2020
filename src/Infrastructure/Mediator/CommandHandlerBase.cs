using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Mediator
{
	public abstract class CommandHandlerBase : HandlerBase
    {
        protected CommandHandlerBase(ToDoContext context)
            : base(context)
        {
        }
    }
}
