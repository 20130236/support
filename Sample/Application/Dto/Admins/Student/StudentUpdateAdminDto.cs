namespace Sample.Application.Dto.Admins
{
    [MapToEntity<Student>(true)]
    public class StudentUpdateAdminDto : BaseDto
    {
        public string Name { get; set; }

        public Guid ClassId { get; set; }
    }
}
