using Domain.Products;
using Domain.Users;

namespace Domain.Carts
{
    public interface ICartRepository
    {
        Task<Cart?> GetByIdAsync(UserId userId, ProductId productId);

        void Add(Cart cart);

        void Update(Cart cart);

        void Remove(Cart cart);
    }
}
