using Domain.Carts;
using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        
        DbSet<Product> Products { get; set; }

        DbSet<Cart> Carts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
