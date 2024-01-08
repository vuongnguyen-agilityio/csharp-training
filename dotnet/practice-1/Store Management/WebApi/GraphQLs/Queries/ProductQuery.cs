using Application.Products.Get;
using Domain.Products;
using GraphQL;
using GraphQL.Types;
using MediatR;
using WebApi.GraphQLs.Types;

namespace WebApi.GraphQLs.Queries
{
	public class ProductQuery : ObjectGraphType<object>
    {

        public ProductQuery(ISender sender)
		{
            Name = "Query";

            Field<ProductType>("product")
                .Argument<IdGraphType>("id", "id of the human")
                .ResolveAsync(async context =>
                {
                    var id = new ProductId(new Guid(context.GetArgument<string>("id")));
                    return new ProductResponse(new Guid(context.GetArgument<string>("id")), "P1", "12121212", "VND", 1, new DateTime(), new DateTime());
                    //return await sender.Send(new GetProductQuery(id));
                });
        }
	}
}