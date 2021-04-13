using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Database.Entities.Department;
using UserManagement.Database.Entities.Role;
using UserManagement.Database.Entities.User;

namespace UserManagement.Database.DatabaseContext
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<Role> Roles { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<User> Users { get; set; }
    }
}
