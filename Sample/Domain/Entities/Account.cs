using TripleSix.Core.Validation;

namespace Sample.Domain.Entities
{
    [Comment("Tài khoản")]
    public class Account : StrongEntity<Account>
    {
        [Comment("Tên tài khoản")]
        [MustNoSpace]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Comment("Mật khẩu")]
        [Required]
        [MustTrim]
        [MustNoSpace]
        [MaxLength(50)]
        [MustRegExr("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$")]
        public string Password { get; set; }

        [Comment("Tên vai trò")]
        [MaxLength(200)]
        public string RoleName { get; set; }

        [Comment("Mã vai trò")]
        [MaxLength(200)]
        public string RoleCode { get; set; }

        /// <inheritdoc/>
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.UserName).IsUnique();
            //builder.HasIndex(x => x.Name);
        }
    }
}
