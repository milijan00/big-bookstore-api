using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public class BookConfiguration : BaseEntityConfiguration<Book>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.AuthorId).IsRequired();
            builder.Property(x => x.Pages).IsRequired();
            builder.Property(x => x.LetterId).IsRequired();
            builder.Property(x => x.BindingTypeId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Image).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Carts)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
