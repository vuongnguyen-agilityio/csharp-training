using Domain.Profiles;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasConversion(
                profileId => profileId.Value,
                value => new ProfileId(value));

            builder.Property(p => p.UserId).HasConversion(
                userId => userId.Value,
                value => new UserId(value));
            builder.HasIndex(p => p.UserId).IsUnique();
        }
    }
}
