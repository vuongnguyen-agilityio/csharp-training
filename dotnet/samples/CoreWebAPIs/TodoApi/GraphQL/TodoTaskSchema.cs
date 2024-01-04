using GraphQL.Instrumentation;
using GraphQL.Types;

namespace TodoApi.GraphQL
{
	public class TodoTaskSchema : Schema
    {
        public TodoTaskSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = (TodoTaskQuery)provider.GetService(typeof(TodoTaskQuery)) ?? throw new InvalidOperationException();

            // TODO: Add mutation for todotask

            FieldMiddleware.Use(new InstrumentFieldsMiddleware());
        }
    }
}