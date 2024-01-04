using GraphQL.Types;
using TodoApi.Services;
using TodoApi.Models;

namespace TodoApi.GraphQL
{

    public class TodoTaskQuery : ObjectGraphType<object>
    {
        private readonly ITodoTasksService _todoTasksService;
        
        public TodoTaskQuery(ITodoTasksService todoTasksService)
        {
            Name = "Query";
            _todoTasksService = todoTasksService;

            Field<TodoTaskType>("todo")
                .Resolve(context => _todoTasksService.GetAsync("6596851ddbbcfb949e4ec4ce"));
        }
    }

    public class TodoTaskType : ObjectGraphType<TodoTask>
    {
        public TodoTaskType()
        {
            Name = "TodoTask"; // or any other name you consider

            Field(x => x.Id, nullable: true).Description("The Id of the Task.");
            Field(x => x.Title).Description("The title of the Task.");
            Field(x => x.Priority);
            Field(x => x.Status);
        }
    }
}
