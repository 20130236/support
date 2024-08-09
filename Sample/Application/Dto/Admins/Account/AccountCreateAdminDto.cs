namespace Sample.Application.Dto.Admins
{
    [MapToEntity<Account>(nameof(Account.RoleName))]
    //[MapToEntity<Account, AccountCreateAdminMapAction>(true)]
    public class AccountCreateAdminDto : BaseDto
    {
        [Required]
        [MustNoSpace]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MustTrim]
        [MustNoSpace]
        [MaxLength(50)]
        [MustRegExr("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$")]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string RoleCode { get; set; } 
    }

    public class AccountCreateAdminMapAction : IMappingAction<AccountCreateAdminDto, Account>
    {
        public void Process(AccountCreateAdminDto source, Account destination, ResolutionContext context)
        {
            destination.RoleName = source.RoleCode.Equals("GV") ? "Giáo viên" : "Sinh viên";
        }
    }
}
