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
        }
    }
}
