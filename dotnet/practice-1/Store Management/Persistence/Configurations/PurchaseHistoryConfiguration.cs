using Domain.PurchaseHistories;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class PurchaseHistoryConfiguration : IEntityTypeConfiguration<PurchaseHistory>
    {
        public void Configure(EntityTypeBuilder<PurchaseHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasConversion(
                purchaseHistoryId => purchaseHistoryId.Value,
                value => new PurchaseHistoryId(value));

            builder.Property(p => p.UserId).HasConversion(
                userId => userId.Value,
                value => new UserId(value));

            builder.OwnsOne(p => p.Amount, amountBuilder =>
            {
                amountBuilder.Property(m => m.Currency).HasMaxLength(3);
            });
        }
    }
}
