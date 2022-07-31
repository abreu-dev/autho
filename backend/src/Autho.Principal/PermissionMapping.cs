using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autho.Principal
{
    public class PermissionMapping : IEntityTypeConfiguration<PermissionData>
    {
        public void Configure(EntityTypeBuilder<PermissionData> builder)
        {
            builder.ToTable(PermissionData.TableName);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(PermissionData.NameMaxLength);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(PermissionData.CodeMaxLength);
        }
    }
}
