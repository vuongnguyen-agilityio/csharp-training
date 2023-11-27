using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
