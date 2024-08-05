using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample.Infrastructure.DataContext
{
    public partial class ApplicationDbContext : BaseDbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
            : base(typeof(IApplicationDbContext).Assembly, Assembly.GetExecutingAssembly())
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseNpgsql(_configuration.GetConnectionString("Default"));

#if DEBUG
            builder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
#endif
        }
    }
}
