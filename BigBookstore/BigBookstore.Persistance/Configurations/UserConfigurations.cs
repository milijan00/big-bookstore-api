using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public class UserConfigurations : BaseEntityConfiguration<User>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Carts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
