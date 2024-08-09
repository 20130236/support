namespace Sample.WebApi.Abstracts
{
    [Route("Admin/[controller]")]
    [Authorize]
    [RequireIssuer("IDENTITY")]
    [SwaggerTagGroup("Admin", 2)]
    [RequireScope("admin")]
    public abstract class AdminController : BaseController
    {
    }
}