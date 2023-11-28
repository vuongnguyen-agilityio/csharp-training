using Domain.Carts;
using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Cart?> GetByIdAsync(UserId userId, ProductId productId)
        {
            return _context.Carts
                .SingleOrDefaultAsync(c => c.UserId == new UserId(userId.Value) && c.ProductId == new ProductId(productId.Value));
        }

        public Task<List<Cart>> ListAsync()
        {
            return _context.Carts.ToListAsync();
        }

        public void Add(Cart cart)
        {
            _context.Carts.Add(cart);
        }

        public void Update(Cart cart)
        {
            _context.Carts.Update(cart);
        }

        public void Remove(Cart cart)
        {
            _context.Carts.Remove(cart);
        }
    }
}
