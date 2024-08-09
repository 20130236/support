using Sample.WebApi.Controllers.Admins;

namespace Sample.WebApi.Controllers.Common
{
    [SwaggerTag("Sinh viên")]
    [AdminReadEndpoint<StudentController, Student, StudentDataAdminDto, StudentDetailAdminDto, StudentFilterAdminDto>]
    [AdminCreateEndpoint<StudentController, Student, StudentCreateAdminDto>]
    [AdminUpdateEndpoint<StudentController, Student, StudentUpdateAdminDto>]
    [AdminSoftDeleteEndpoint<StudentController, Student>]
    //[Authorize(Policy = "Studentmangement")]
    [RequireScope("GV")]
    public class StudentController : AdminController
    {
    }
}
