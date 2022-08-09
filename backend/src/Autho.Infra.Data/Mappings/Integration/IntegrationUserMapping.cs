using Autho.Infra.Data.Entities.Integration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autho.Infra.Data.Mappings.Integration
{
    public class IntegrationUserMapping : IEntityTypeConfiguration<IntegrationUserData>
    {
        public void Configure(EntityTypeBuilder<IntegrationUserData> builder)
        {
            builder.ToTable(IntegrationUserData.TableName);

            builder.Property(x => x.Name);

            builder.Property(x => x.Email);

            builder.Property(x => x.Login);

            builder.Property(x => x.Password);

            builder.Property(x => x.Language);

            builder.HasOne(x => x.Integration)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.IntegrationId);
        }
    }
}
