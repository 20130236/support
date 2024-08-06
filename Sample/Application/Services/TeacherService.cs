using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services
{
    public interface ITeacherService : IStrongService<Teacher>
    {
    }

    public class TeacherService : StrongService<Teacher>, ITeacherService
    {
        public TeacherService(IDbDataContext db)
            : base(db)
        {
        }

        public IApplicationDbContext Db { get; set; }
    }
}
