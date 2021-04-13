using Autofac;

namespace UserManagement
{
    internal partial class Startup
    {
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<Database.Registrations>();
            builder.RegisterModule<Registrations>();
        }
    }
}
