
using Domain.Products;
using GraphQL.Types;

namespace WebApi.GraphQLs.Types
{
	public class ProductType : ObjectGraphType<Product>
    {
		public ProductType()
		{
            Name = nameof(Product); // or any other name you consider

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Product.");
            Field(x => x.Name).Description("The name of the product.");
            Field(x => x.Sku, type: typeof(StringGraphType)).Description("The SKU of the product");
            Field(x => x.Price.Currency).Description("The currency of product price");
            Field(x => x.Price.Amount).Description("The amount of product price");
            Field(x => x.CreatedDate);
            Field(x => x.UpdatedDate);
        }
    }
}

