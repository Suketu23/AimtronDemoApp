using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Database.Constants;
using UserManagement.Database.Entities.User;

namespace UserManagement.Database.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(Constant.UserTableName, Constant.SchemaName);

            builder.Property(u => u.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
            builder.Property(u => u.PhoneNumber).HasMaxLength(20).IsRequired(); 
        }
    }
}
