namespace Sample.Application.Dto.Admins
{
    [MapToEntity<RefreshToken>]
    public class AccountRefreshTokenAdminDto : BaseDto
    {
        [Required]
        public string Token { get; set; }

    }
}
