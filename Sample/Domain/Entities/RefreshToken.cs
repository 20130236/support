namespace Sample.Domain.Entities
{
    [Comment("Token")]
    public class RefreshToken : StrongEntity<RefreshToken>
    {
        public string Token { get; set; }
    }
}
