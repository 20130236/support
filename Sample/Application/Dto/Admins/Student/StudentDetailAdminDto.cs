namespace Sample.Application.Dto.Admins
{
    [MapFromEntity<Student>]
    public class StudentDetailAdminDto : StudentDataAdminDto
    {
        public ClassDataAdminDto Class { get; set; }
    }
}
