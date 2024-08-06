namespace Sample.Application.Dto.Admins
{
    [MapFromEntity<Class>]
    public class ClassDataAdminDto : BaseDataAdminDto
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
