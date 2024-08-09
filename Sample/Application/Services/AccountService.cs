using Autofac.Core;
using Elastic.Clients.Elasticsearch;
using Sample.Application.Dto.Admins;

namespace Sample.Application.Services
{
    public interface IAccountService : IStrongService<Account>
    {
        Account? GetAccount(string username, string password);

        bool AvailableUserName(string username);

        bool AvailableRoleCode(string rolecode);

        bool AvailableRefreshToken(string token);

        Account? GetAccountById(string id);

        /*void createToken(string token);*/
    }

    public class AccountService : StrongService<Account>, IAccountService
    {
        public AccountService(IDbDataContext db)
            : base(db)
        {
        }

        public IApplicationDbContext Db { get; set; }

        public Account? GetAccount(string username, string password)
        {
            /*User user = (from u in db.Users
                         where u.Username.Equals(username)
                         select u).FirstOrDefault();*/
            var account = Db.Account.FirstOrDefault(acc => acc.UserName.Equals(username));
            if (account != null) {
                if(account.Password.Equals(HashHelper.MD5Hash(password))) { return account; }
            }
            return null;
        }

        public bool AvailableUserName(string username)
        {
            var account = Db.Account.FirstOrDefault(acc => acc.UserName.Equals(username));
            return account == null ? false : true;
        }

        public bool AvailableRoleCode(string rolecode)
        {
            return rolecode.Equals("GV") || rolecode.Equals("SV");
        }

        public bool AvailableRefreshToken(string token)
        {
            var result = Db.RefreshToken.FirstOrDefault(t => t.Token.Equals(token));
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public Account? GetAccountById(string id)
        {
            var result = Db.Account.FirstOrDefault(acc => acc.Id.Equals(id));
            return null;
        }

/*        public void createToken(string token)
        {
            Db.RefreshToken.Add(new RefreshToken()
            {
                Token = token
            });
        }*/
    }
}
