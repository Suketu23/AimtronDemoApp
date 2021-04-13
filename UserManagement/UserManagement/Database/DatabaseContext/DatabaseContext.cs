using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserManagement.Database.Entities.Department;
using UserManagement.Database.Entities.Role;
using UserManagement.Database.Entities.User;
using UserManagement.Database.EntityConfigurations;

namespace UserManagement.Database.DatabaseContext
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
