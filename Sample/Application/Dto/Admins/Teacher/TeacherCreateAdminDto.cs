namespace Sample.Application.Dto.Admins
{
    [MapToEntity<Teacher>]
    public class TeacherCreateAdminDto : BaseDto
    {
        [Required]
        [MustTrim]
        [MustNoSpace]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MustTrim]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
