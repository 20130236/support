namespace Sample.WebApi.Controllers.Common
{
    [SwaggerTag("Lớp học")]
    [CommonReadEndpoint<ClassController, Class, ClassDataAdminDto, ClassDetailAdminDto, ClassFilterAdminDto>]
    [CommonCreateEndpoint<ClassController, Class, ClassCreateAdminDto>]
    [CommonUpdateEndpoint<ClassController, Class, ClassUpdateAdminDto>]
    [CommonSoftDeleteEndpoint<ClassController, Class>]
    public class ClassController : CommonController
    {
    }
}
