using Hangfire.PostgreSql.Properties;

namespace Sample.Application.Dto.Admins
{
    [MapToEntity<Student, StudentCreateAdminMapAction>(nameof(Student.Code))]
    public class StudentCreateAdminDto : BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid ClassId { get; set; }
    }

    public class StudentCreateAdminMapAction : IMappingAction<StudentCreateAdminDto, Student>
    {
        public void Process(StudentCreateAdminDto source, Student destination, ResolutionContext context)
        {
            destination.Code = RandomHelper.RandomString(10);
        }
    }
}
