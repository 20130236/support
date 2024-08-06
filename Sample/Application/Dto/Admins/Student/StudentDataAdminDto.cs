namespace Sample.Application.Dto.Admins
{
    [MapFromEntity<Student>]
    public class StudentDataAdminDto : BaseDataAdminDto
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
