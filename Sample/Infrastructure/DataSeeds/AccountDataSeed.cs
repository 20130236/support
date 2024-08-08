namespace Sample.Infrastructure.Seeds
{
    public class AccountDataSeed : BaseDataSeed
    {
        /// <inheritdoc/>
        public override void OnDataSeeding(ModelBuilder builder, DatabaseFacade database)
        {
            //var cmd = database.GetDbConnection().CreateCommand();
            //Console.WriteLine(cmd.Connection.State);

            var accounts = new List<Account>()
            {
                new Account
                {
                    Id = Guid.Parse("653dc4d4-ca05-45ac-83cd-e98fa91b890f"),
                    UserName = "usernameSV",
                    Password = "123",
                    RoleCode = "SV",
                    RoleName = "Sinh viên"
                },
                new Account
                {
                    Id = Guid.Parse("6f6e615e-feeb-40b5-b53c-7f9056082d36"),
                    UserName = "usernameGV",
                    Password = "123",
                    RoleCode = "GV",
                    RoleName = "Giáo viên"
                }
            };

            builder.Entity<Account>().HasData(accounts);
        }
    }
}
