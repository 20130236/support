namespace Sample.Application.Services
{
    public interface IClassService : IStrongService<Class>
    {
    }

    public class ClassService : StrongService<Class>, IClassService
    {
        public ClassService(IDbDataContext db)
            : base(db)
        {
        }

        public IApplicationDbContext Db { get; set; }
    }
}
