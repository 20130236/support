using Sample.Domain.Entities;

namespace Sample.WebApi.Abstracts
{
    [Route("Admin/[controller]")]
    [Authorize]
    [RequireIssuer("IDENTITY")]
    [SwaggerTagGroup("Admin", 2)]
    [RequireScope("GV")]
    public abstract class TeacherScopeController : BaseController
    {
    }
}