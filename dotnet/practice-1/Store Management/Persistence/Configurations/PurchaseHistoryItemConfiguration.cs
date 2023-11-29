using Domain.Products;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class PurchaseHistoryItemConfiguration : IEntityTypeConfiguration<PurchaseHistoryItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseHistoryItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasConversion(
                purchaseHistoryItemId => purchaseHistoryItemId.Value,
                value => new PurchaseHistoryItemId(value));

            builder.Property(p => p.PurchaseHistoryId).HasConversion(
                purchaseHistoryId => purchaseHistoryId.Value,
                value => new PurchaseHistoryId(value));

            builder.Property(p => p.ProductId).HasConversion(
                productId => productId.Value,
                value => new ProductId(value));

            builder.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(m => m.Currency).HasMaxLength(3);
            });
        }
    }
}
