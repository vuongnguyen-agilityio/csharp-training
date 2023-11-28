using Domain.Products;

namespace Domain.Carts
{
    public sealed class CartNotFoundException : Exception
    {
        public CartNotFoundException(ProductId productId)
            : base($"The order with the Product ID = {productId.Value} was not found")
        {
        }
    }
}

