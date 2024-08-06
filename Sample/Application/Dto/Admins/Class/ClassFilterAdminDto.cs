namespace Sample.Application.Dto.Admins
{
    public class ClassFilterAdminDto : BaseFilterAdminDto<Class>
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        /// <inheritdoc/>
        public override Task<IQueryable<Class>> ToQueryable(IQueryable<Class> query, IServiceProvider serviceProvider)
        {
            var result = query
                .WhereIf(Code.IsNotNullOrEmpty(), x => EF.Functions.Like(x.Code, $"%{Code}%"))
                .WhereIf(Name.IsNotNullOrEmpty(), x => EF.Functions.Like(x.Name, $"%{Name}%"));

            return Task.FromResult(result);
        }
    }
}
