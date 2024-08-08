//using System.IdentityModel.Tokens.Jwt;
//using System.IO;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using Azure.Core;
//using Elastic.Clients.Elasticsearch;
//using Hangfire.Common;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.IdentityModel.Tokens;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Sample.Application.Services;
//using TripleSix.Core.Appsettings;
//using TripleSix.Core.Helpers;
//using TripleSix.Core.Identity;

//namespace Sample.WebApi.Controllers.Common
//{
//    public class CommonAuthenEndpoint<TController, TEntity> : CommonController,
//        IControllerEndpoint<TController, CommonAuthenEndpointAttribute<TController, TEntity>>
//        where TController : BaseController
//        where TEntity : class, IStrongEntity
//    {
//        public IStrongService<TEntity> Service { get; set; }

//        public IAccountService AccountService { get; set; }

//        [HttpPost]
//        [Route("Login")]
//        [SwaggerOperation("Đăng nhập [controller]")]
//        public IActionResult Login([FromBody] AccountLoginDto input)
//        {
//            var acc = AccountService.GetAccount(input.Username, input.Password);
//            if(acc == null)
//            {
//                var errorResult = new ErrorResult(400, "login_failed", "Đăng nhập không thành công");
//                return errorResult;
//            } else
//            {
//                var accessToken = GenerateAccessToken(acc);
//                var refreshToken = GenerateRefreshToken(acc);

//                return DataResult(new AccountDataAdminDto() { AccessToken = accessToken.Result,
//                    RefreshToken = refreshToken.Result
//                });
//            }
//        }

///*        [HttpPost]
//        [SwaggerOperation("Đăng ký [controller]")]
//        public Task<IActionResult> Signup([FromBody] AccountCreateAdminDto input)
//        {
//            //var acc = AccountService.GetAccount(input.Username, input.Password);
//            if (AccountService.AvailableUserName(input.Username))
//            {
//                var errorResult = new ErrorResult(400, "sigup_failed", "Tên tài khoản đã tồn tại");
//                return errorResult;
//            }
//            else
//            {
//                var result = Service.CreateWithMapper(input);
//                return DataResult(result.Id);
//            }
//        }*/

//        [HttpPost]
//        [Route("Create")]
//        [SwaggerOperation("Đăng ký [controller]")]
//        [Transactional]
//        public async Task<IActionResult> Create([FromBody] AccountCreateAdminDto input)
//        {
//            if (!AccountService.AvailableRoleCode(input.RoleCode))
//            {
//                var errorResult = new ErrorResult(400, "sigup_failed", "Vai trò không tồn tại");
//                return errorResult;
//            }

//            if (AccountService.AvailableUserName(input.Username))
//            {
//                var errorResult = new ErrorResult(400, "sigup_failed", "Tên tài khoản đã tồn tại");
//                return errorResult;
//            }

//            input.Password = HashHelper.MD5Hash(input.Password);
//            var result = await Service.CreateWithMapper(input);
//            return DataResult(result.Id);
//        }

//        [HttpPost]
//        [Route("RefreshToken")]
//        [SwaggerOperation("Làm mới AccessToken [controller]")]
//        [Transactional]
//        public IActionResult RefreshToken([FromBody] string refreshtoken)
//        {
//            if (AccountService.AvailableRefreshToken(refreshtoken))
//            {
//                var handler = new JwtSecurityTokenHandler();
//                var jsonToken = handler.ReadToken(refreshtoken);
//                var tokenS = jsonToken as JwtSecurityToken;
//                string id = tokenS.Claims.First(claim => claim.Type == "Id").Value;

//                //JwtPayload payload = DecodeJwtPayload(refreshtoken);
//                //string id = payload.Id;
//                //var payload = DecodeJwtPayload(refreshtoken);
//                //var acc = AccountService.GetFirstOrDefault(acc => acc.id.equals(payload.id));
//                var acc = AccountService.GetAccountById(id);
//                //return DataResult(result);
//                var newAccessToken = GenerateAccessToken(acc);
//                return DataResult(newAccessToken);
//            }

//            var errorResult = new ErrorResult(400, "sigup_failed", "Vai trò không tồn tại");
//            return errorResult;
//        }

//        private async Task<string> GenerateAccessToken(Account account)
//        {
//            //var jwt = 
//            var jwtTokenHandler = new JwtSecurityTokenHandler();
//            var secretKeyBytes = Encoding.UTF8.GetBytes("this is my custom Secret key for authentication, this is my custom Secret key for authentication");
//            //var secretKeyBytes = Convert.FromBase64String("thisismycustomsecrekeythisismycustomsecretkeykeykeykeykeykeythisismycustomsecrekeythisismycustomsecretkeykeykeykeykeykey");

///*            // INITIALIZE RSA
//            using var rsa = RSA.Create();
//            // Since the private key starts with "BEGIN PRIVATE KEY" it's PKCS8 encoded
//            rsa.ImportPkcs8PrivateKey(secretKeyBytes, out _);*/
//            var tokenDescription = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[] {
//                    new Claim("Id", account.Id.ToString()),
//                    new Claim("UserName", account.UserName),
//                    new Claim(ClaimTypes.Role, account.RoleCode.ToString()),
//                    new Claim("RoleCode", account.RoleCode.ToString()),
//                    new Claim("RoleName", account.RoleName),
//                    new Claim("TokenId", Guid.NewGuid().ToString()),
//                    new Claim("issuer", "IDENTITY"),
//                    new Claim("scope", "admin")
//                }),
//                Expires = DateTime.UtcNow.AddMinutes(10),
//                SigningCredentials = new SigningCredentials(
//                    new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
//            };

//            var token = jwtTokenHandler.CreateToken(tokenDescription);
//            string accessToken = jwtTokenHandler.WriteToken(token);
//            return await Task.FromResult(accessToken);
//        }

//        private async Task<string> GenerateRefreshToken(Account account)
//        {
//            var jwtTokenHandler = new JwtSecurityTokenHandler();
//            var secretKeyBytes = Encoding.UTF8.GetBytes("this is my custom Secret key for authentication, this is my custom Secret key for authentication");
//            var tokenDescription = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[] {
//                    new Claim("Id", account.Id.ToString()),
//                    /*new Claim("UserName", account.UserName),
//                    *//*new Claim(ClaimTypes.Role,account.RoleCode),*//*
//                    new Claim("RoleCode",account.RoleCode),
//                    new Claim("RoleName", account.RoleName),*/
//                    new Claim("TokenId", Guid.NewGuid().ToString())
//                }),
//                Expires = DateTime.UtcNow.AddMinutes(60),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
//            };

//            var token = jwtTokenHandler.CreateToken(tokenDescription);
//            string refreshToken = jwtTokenHandler.WriteToken(token);
//            return await Task.FromResult(refreshToken);
//        }

//        private bool ValidateToken(string token)
//        {
//            return AccountService.AvailableRefreshToken(token);
//        }

//        private JwtPayload DecodeJwtPayload(string jwtToken)
//        {
//            string[] parts = jwtToken.Split('.');
//            string payloadJson = Encoding.UTF8.GetString(Convert.FromBase64String(parts[1]));
//            JwtPayload payload = JsonConvert.DeserializeObject<JwtPayload>(payloadJson);
//            return payload;
//        }
//    }

//    public class CommonAuthenEndpointAttribute<TController, TEntity>
//        : BaseControllerEndpointAttribute
//        where TController : BaseController
//        where TEntity : class, IStrongEntity
//    {
//        public override Type EndpointType => typeof(CommonAuthenEndpoint<TController,TEntity>);
//    }
//}
