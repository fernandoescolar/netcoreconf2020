using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Mediator
{
	public abstract class HandlerBase
    {
        protected HandlerBase(ToDoContext context)
        {
            Context = context;
        }

        protected ToDoContext Context { get; private set; }
    }
}
