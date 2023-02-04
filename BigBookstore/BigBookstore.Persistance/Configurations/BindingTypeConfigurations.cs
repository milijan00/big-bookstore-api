using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public class BindingTypeConfigurations : BaseEntityConfiguration<BindingType>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<BindingType> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Books)
                .WithOne(x => x.BindingType)
                .HasForeignKey(x => x.BindingTypeId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
