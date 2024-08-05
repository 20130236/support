using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Entities
{
    public class Class : StrongEntity<Class>
    {
        [Comment("Mã số")]
        [MaxLength(50)]
        public string Code { get; set; }

        [Comment("Tên gọi")]
        [MaxLength(250)]
        public string Name { get; set; }

        public virtual IList<Student>? Students { get; set; }

        public Guid TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }

        public override void Configure(EntityTypeBuilder<Class> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Code).IsUnique();
            builder.HasIndex(x => x.Name);
        }
    }
}
