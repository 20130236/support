namespace Sample.Application.Dto.Admins
{
    [MapToEntity<Class>]
    public class ClassCreateAdminDto : BaseDto
    {
        [Required]
        [MustTrim]
        [MustUpperCase]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MustTrim]
        [MaxLength(200)]
        public string Name { get; set; }


        [Required]
        public Guid TeacherId { get; set; }

    }
}
