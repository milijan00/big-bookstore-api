using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public class RoleConfigurations : BaseEntityConfiguration<Role>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Name);
        }
    }
}
