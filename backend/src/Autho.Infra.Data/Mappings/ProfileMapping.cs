using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autho.Principal
{
    public class ProfileMapping : IEntityTypeConfiguration<ProfileData>
    {
        public void Configure(EntityTypeBuilder<ProfileData> builder)
        {
            builder.ToTable(ProfileData.TableName);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ProfileData.NameMaxLength);
        }
    }
}
