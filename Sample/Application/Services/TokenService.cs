namespace Sample.Application.Services
{
    public interface ITokenService : IStrongService<RefreshToken>
    {
        bool AvailableRoleCode(string rolecode);
    }

    public class TokenService : StrongService<RefreshToken>, ITokenService
    {
        public TokenService(IDbDataContext db)
            : base(db)
        {
        }

        public IApplicationDbContext Db { get; set; }

        public bool AvailableRoleCode(string rolecode)
        {
            //var token = Db.RefreshToken.Get(rolecode);
            return rolecode.Equals("GV") || rolecode.Equals("SV");
        }
    }
}
