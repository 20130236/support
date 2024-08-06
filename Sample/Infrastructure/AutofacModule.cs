using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using Sample.Infrastructure.DataContext;
using TripleSix.Core.AutofacModules;

namespace Sample.Infrastructure
{
    public class AutofacModule : BaseModule
    {
        public AutofacModule(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterDbContext<ApplicationDbContext>()
                .WithParameter("configuration", Configuration);
            builder.RegisterAllAutoInjection(assembly);
        }
    }
}
