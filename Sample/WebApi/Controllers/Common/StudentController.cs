namespace Sample.WebApi.Controllers.Common
{
    [SwaggerTag("Sinh viên")]
    [CommonReadEndpoint<StudentController, Student, StudentDataAdminDto, StudentDetailAdminDto, StudentFilterAdminDto>]
    [CommonCreateEndpoint<StudentController, Student, StudentCreateAdminDto>]
    [CommonUpdateEndpoint<StudentController, Student, StudentUpdateAdminDto>]
    [CommonSoftDeleteEndpoint<StudentController, Student>]
    public class StudentController : CommonController
    {
    }
}
