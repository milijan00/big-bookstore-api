using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            this.ConfigureChildProperties(builder);
        }

        public abstract void ConfigureChildProperties(EntityTypeBuilder<T> builder);
    }
}
