namespace Sample.Infrastructure.DataContext
{
    public partial class ApplicationDbContext : IApplicationDbContext
    {
        /// <inheritdoc/>
        public DbSet<Account> Account { get; set; }

        /// <inheritdoc/>
        public DbSet<Site> Site { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<RefreshToken> RefreshToken { get; set; }
    }
}
