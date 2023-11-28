using Domain.Carts;
using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProductId});

            builder.Property(p => p.UserId).HasConversion(
                userId => userId.Value,
                value => new UserId(value));

            builder.Property(p => p.ProductId).HasConversion(
                productId => productId.Value,
                value => new ProductId(value));
        }
    }
}
