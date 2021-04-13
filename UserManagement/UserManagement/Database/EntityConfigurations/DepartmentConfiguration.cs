using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Database.Constants;
using UserManagement.Database.Entities.Department;

namespace UserManagement.Database.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(Constant.DepartmentTableName, Constant.SchemaName);

            builder.Property(d => d.Name).HasColumnName("Name").HasMaxLength(25).IsRequired();
        }
    }
}
