namespace Sample.WebApi.Controllers.Common
{
    [SwaggerTag("Tài Khoản")]
    [CommonAuthenEndpoint<AccountController, Account>]
    public class AccountController : CommonController
    {
    }
}
