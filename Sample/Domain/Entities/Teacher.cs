namespace Sample.Domain.Entities
{
    public class Teacher : StrongEntity<Teacher>
    {
        [Comment("Mã số")]
        [MaxLength(50)]
        public string Code { get; set; }

        [Comment("Tên gọi")]
        [MaxLength(250)]
        public string Name { get; set; }

        /*        public Guid ClassId { get; set; }

                [ForeignKey(nameof(ClassId))]
                public virtual Class Class { get; set; }*/
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Code).IsUnique();
            builder.HasIndex(x => x.Name);
        }
    }
}
