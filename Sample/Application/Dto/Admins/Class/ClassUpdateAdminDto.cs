namespace Sample.Application.Dto.Admins
{
    [MapToEntity<Class>(true)]
    public class ClassUpdateAdminDto : BaseDto
    {
        [MustTrim]
        [MaxLength(200)]
        public string Name { get; set; }

        public Guid TeacherId { get; set; }
    }
}
