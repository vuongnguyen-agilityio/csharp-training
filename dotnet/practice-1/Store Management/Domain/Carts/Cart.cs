using Domain.Primitives;
using Domain.Products;
using Domain.Users;

namespace Domain.Carts
{
    /*
     * The CartId is the combination of UserId and ProductId
     */
    public class Cart : BaseEntity
    {
        public Cart(UserId userId, ProductId productId, decimal quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }

        private Cart() { }

        public UserId UserId { get; private set;}

        public ProductId ProductId { get; private set; }

        // The quantity of an added product in cart
        public decimal Quantity { get; private set; }

        public void Update(UserId userId, ProductId productId, decimal quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
