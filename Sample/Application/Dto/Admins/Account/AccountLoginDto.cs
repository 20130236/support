using Elastic.Clients.Elasticsearch;

namespace Sample.Application.Dto.Admins
{
    public class AccountLoginDto : BaseDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
