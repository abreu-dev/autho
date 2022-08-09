using Autho.Infra.Data.Entities.Integration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autho.Infra.Data.Mappings.Integration
{
    public class IntegrationMapping : IEntityTypeConfiguration<IntegrationData>
    {
        public void Configure(EntityTypeBuilder<IntegrationData> builder)
        {
            builder.ToTable(IntegrationData.TableName);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.StartDateImport);

            builder.Property(x => x.EndDateImport);
        }
    }
}
