using System;
using Application.Data;
using GraphQL.Instrumentation;
using GraphQL.Types;
using WebApi.GraphQLs.Queries;

namespace WebApi.GraphQLs.Schemas
{
	public class ProductSchema : Schema
    {
		public ProductSchema(IServiceProvider provider) : base(provider)
        {
            Query = (ProductQuery)provider.GetService(typeof(ProductQuery)) ?? throw new InvalidOperationException();

            // TODO: Add mutation for todotask

            FieldMiddleware.Use(new InstrumentFieldsMiddleware());
        }
	}
}

