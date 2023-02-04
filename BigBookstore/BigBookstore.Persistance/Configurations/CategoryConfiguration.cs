using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
