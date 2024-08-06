using Sample.Application.Dto.Admins;

namespace Sample.Application.Services
{
    public interface IStudentService : IStrongService<Student>
    {
    }

    public class StudentService : StrongService<Student>, IStudentService
    {
        public StudentService(IDbDataContext db)
            : base(db)
        {
        }

        public IApplicationDbContext Db { get; set; }
    }
}
