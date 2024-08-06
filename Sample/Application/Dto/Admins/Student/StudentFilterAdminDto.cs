namespace Sample.Application.Dto.Admins
{
    public class StudentFilterAdminDto : BaseFilterAdminDto<Student>
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public Guid? ClassId { get; set; }

        /// <inheritdoc/>
        public override Task<IQueryable<Student>> ToQueryable(IQueryable<Student> query, IServiceProvider serviceProvider)
        {
            var result = query
                .WhereIf(Code.IsNotNullOrEmpty(), x => EF.Functions.Like(x.Code, $"%{Code}%"))
                .WhereIf(Name.IsNotNullOrEmpty(), x => EF.Functions.Like(x.Name, $"%{Name}%"))
                .WhereIf(ClassId.HasValue, x => x.ClassId == ClassId);

            return Task.FromResult(result);
        }
    }
}
