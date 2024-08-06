﻿namespace Sample.Application.Dto.Admins
{
    public class TeacherFilterAdminDto : BaseFilterAdminDto<Teacher>
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        /// <inheritdoc/>
        public override Task<IQueryable<Teacher>> ToQueryable(IQueryable<Teacher> query, IServiceProvider serviceProvider)
        {
            var result = query
                .WhereIf(Code.IsNotNullOrEmpty(), x => EF.Functions.Like(x.Code, $"%{Code}%"))
                .WhereIf(Name.IsNotNullOrEmpty(), x => EF.Functions.Like(x.Name, $"%{Name}%"));

            return Task.FromResult(result);
        }
    }
}
