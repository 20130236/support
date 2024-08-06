﻿namespace Sample.Application.Dto.Admins
{
    [MapFromEntity<Teacher>]
    public class TeacherDataAdminDto : BaseDataAdminDto
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
