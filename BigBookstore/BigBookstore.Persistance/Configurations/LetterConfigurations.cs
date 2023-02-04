using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public class LetterConfigurations : BaseEntityConfiguration<Letter>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<Letter> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Letter)
                .HasForeignKey(x => x.LetterId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
