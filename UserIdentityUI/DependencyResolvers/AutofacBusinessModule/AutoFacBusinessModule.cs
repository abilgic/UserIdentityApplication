using Autofac;
using Microsoft.EntityFrameworkCore;
using UserIdentityBAL.Services;
using UserIdentityDAL.Data;
using UserIdentityDAL.Repositories;

namespace UserIdentityUI.DependencyResolvers.AutofacBusinessModule
{
    public class AutoFacBusinessModule : Module
    {
        private readonly IConfiguration Configuration;

        public AutoFacBusinessModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); /// builder.Configuration.GetConnectionString("YOURCONNECTIONSTRING"));
                return new ApplicationDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();
        }
    }
}
