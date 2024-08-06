namespace Sample.WebApi.Controllers.Common
{
    [SwaggerTag("Giáo Viên")]
    [CommonReadEndpoint<TeacherController, Teacher, TeacherDataAdminDto, TeacherDetailAdminDto, TeacherFilterAdminDto>]
    [CommonCreateEndpoint<TeacherController, Teacher, TeacherCreateAdminDto>]
    [CommonUpdateEndpoint<TeacherController, Teacher, TeacherUpdateAdminDto>]
    [CommonSoftDeleteEndpoint<TeacherController, Teacher>]
    public class TeacherController : CommonController
    {
    }
}
