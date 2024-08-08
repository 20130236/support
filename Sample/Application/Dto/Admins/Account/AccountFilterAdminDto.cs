namespace Sample.Application.Dto.Admins
{
    public class AccountFilterAdminDto : BaseFilterAdminDto<Account>
    {
        public string? UserName { get; set; }

        public override Task<IQueryable<Account>> ToQueryable(IQueryable<Account> query, IServiceProvider serviceProvider)
        {
            var result = query
                .WhereIf(UserName.IsNotNullOrEmpty(), x => EF.Functions.Like(x.UserName, $"%{UserName}%"));

            return Task.FromResult(result);
        }
    }
}
