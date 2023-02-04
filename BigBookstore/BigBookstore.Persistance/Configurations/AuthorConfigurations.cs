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
    public class AuthorConfigurations : BaseEntityConfiguration<Author>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Fullname).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.Fullname).IsUnique();

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
