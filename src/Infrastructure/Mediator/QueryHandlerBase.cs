using AutoMapper;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Mediator
{
	public abstract class QueryHandlerBase : HandlerBase
    {
        protected QueryHandlerBase(ToDoContext context, IMapper mapper)
            : base(context)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }
    }
}
