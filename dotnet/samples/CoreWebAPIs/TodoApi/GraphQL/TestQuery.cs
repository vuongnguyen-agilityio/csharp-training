using GraphQL.Types;
using TodoApi.Services;
using TodoApi.Models;

namespace TodoApi.GraphQL
{

    public class TestQuery : ObjectGraphType
    {
        private readonly ITodoTasksService _todoTasksService;
        
        public TestQuery(ITodoTasksService todoTasksService)
        {
            _todoTasksService = todoTasksService;

            Field<TodoTaskType>("todo")
                .Resolve((context) => _todoTasksService.GetAsync("1"));
        }
    }

    public class TodoTaskType : ObjectGraphType<TodoTask>
    {
        public TodoTaskType()
        {
            Name = "TodoTaskType"; // or any other name you consider

            Field(x => x.Id).Description("The Id of the Task.");
            Field(x => x.Title).Description("The title of the Task.");
        }
    }
}
