using Sample.WebApi.Controllers.Admins;

namespace Sample.WebApi.Controllers.Common
{
    [SwaggerTag("Lớp học")]
    [AdminReadEndpoint<ClassController, Class, ClassDataAdminDto, ClassDetailAdminDto, ClassFilterAdminDto>]
    [AdminCreateEndpoint<ClassController, Class, ClassCreateAdminDto>]
    [AdminUpdateEndpoint<ClassController, Class, ClassUpdateAdminDto>]
    [AdminSoftDeleteEndpoint<ClassController, Class>]
    [RequireScope("SV")]
    public class ClassController : AdminController
    {
    }
}
