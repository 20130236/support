using Sample.WebApi.Controllers.Admins;

namespace Sample.WebApi.Controllers.Common
{
    [SwaggerTag("Giáo Viên")]
    [AdminReadEndpoint<TeacherController, Teacher, TeacherDataAdminDto, TeacherDetailAdminDto, TeacherFilterAdminDto>]
    [AdminCreateEndpoint<TeacherController, Teacher, TeacherCreateAdminDto>]
    [AdminUpdateEndpoint<TeacherController, Teacher, TeacherUpdateAdminDto>]
    [AdminSoftDeleteEndpoint<TeacherController, Teacher>]
    //[Authorize(Policy = "TeacherMangement")]
    //[Authorize(Roles = "GV")]
    public class TeacherController : CommonController
    {
    }
}
