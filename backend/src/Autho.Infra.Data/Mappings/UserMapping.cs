using Autho.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autho.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.ToTable(UserData.TableName);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(UserData.NameMaxLength);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(UserData.EmailMaxLength);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(UserData.LoginMaxLength);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(UserData.PasswordMaxLength);

            builder.Property(x => x.Language)
                .IsRequired();

            builder.Property(x => x.LastAccess);
        }
    }
}
