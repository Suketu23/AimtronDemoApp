using Autofac;
using UserManagement.Database.Entities.Department;
using UserManagement.Database.Entities.Role;
using UserManagement.Database.Entities.User;

namespace UserManagement.Database
{
    public class Registrations : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DatabaseContext.DatabaseContext>().As<DatabaseContext.IDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>().InstancePerDependency();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
        }
    }
}
