using AutoMapper;
using TodoApp.Infrastructure.Data;
using TodoApp.Application.Commands;
using TodoApp.Models;

namespace TodoApp.Infrastructure.Mapping
{
	public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Task, IndexModel.TaskListEntry>();
            CreateMap<Task, EditModel>();
            CreateMap<Task, DeleteModel>();

            CreateMap<EditModel, AddOrEditCommand>();
            CreateMap<DeleteModel, DeleteCommand>();
        }
    }
}
