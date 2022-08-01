using Autho.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autho.Infra.Data.Mappings
{
    public class ProfilePermissionMapping : IEntityTypeConfiguration<ProfilePermissionData>
    {
        public void Configure(EntityTypeBuilder<ProfilePermissionData> builder)
        {
            builder.ToTable(ProfilePermissionData.TableName);

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.ProfileId);

            builder.HasOne(x => x.Permission)
                .WithMany(x => x.Profiles)
                .HasForeignKey(x => x.PermissionId);
        }
    }
}
