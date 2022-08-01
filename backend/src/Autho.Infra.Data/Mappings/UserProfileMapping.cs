using Autho.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autho.Infra.Data.Mappings
{
    public class UserProfileMapping : IEntityTypeConfiguration<UserProfileData>
    {
        public void Configure(EntityTypeBuilder<UserProfileData> builder)
        {
            builder.ToTable(UserProfileData.TableName);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Profiles)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ProfileId);
        }
    }
}
