using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Database.Constants;
using UserManagement.Database.Entities.Role;

namespace UserManagement.Database.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(Constant.RoleTableName, Constant.SchemaName);

            builder.Property(r => r.Name).HasColumnName("Name").HasMaxLength(25).IsRequired();
        }
    }
}
