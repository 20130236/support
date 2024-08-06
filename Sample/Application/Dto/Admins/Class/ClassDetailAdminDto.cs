namespace Sample.Application.Dto.Admins
{
    [MapFromEntity<Class>]
    public class ClassDetailAdminDto : ClassDataAdminDto
    {
        public TeacherDataAdminDto Teacher { get; set; }

        public List<StudentDataAdminDto> Students { get; set; }
    }
}
