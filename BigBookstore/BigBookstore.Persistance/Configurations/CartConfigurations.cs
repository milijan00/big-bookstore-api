using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance.Configurations
{
    public class CartConfigurations : BaseEntityConfiguration<Cart>
    {
        public override void ConfigureChildProperties(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Address).IsRequired(false);

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Cart)
                .HasForeignKey(x => x.CartId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        }
    }
}
