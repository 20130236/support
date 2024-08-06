using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
