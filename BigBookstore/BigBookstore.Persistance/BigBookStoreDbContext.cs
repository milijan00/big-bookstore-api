using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Persistance
{
    public class BigBookStoreDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BindingType> BindingTypes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Letter> Letters { get; set; }
        public DbSet<LoggedException> LoggedExceptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-39RJT5L\SQLEXPRESS;Initial Catalog=BigBookstore;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<CartItem>().HasKey(x => new { x.BookId, x.CartId });
            modelBuilder.Entity<CartItem>().Property(x => x.Quantity).IsRequired().HasDefaultValue(1);
            modelBuilder.Entity<LoggedException>().HasKey(x => x.Id);
            modelBuilder.Entity<LoggedException>().Property(x => x.Message).IsRequired();
            modelBuilder.Entity<LoggedException>().Property(x => x.StackTrace).IsRequired();
            modelBuilder.Entity<LoggedException>().Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()").IsRequired();
            modelBuilder.Entity<LoggedException>().Property(x => x.IsSolved).HasDefaultValue(false).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
        public async  override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if(this.ChangeTracker.HasChanges())
            {
                var entries = this.ChangeTracker.Entries();
                foreach (var e in entries)
                {
                    if(e.State == EntityState.Added)
                    {
                        var entity = e.Entity as BaseEntity;
                        entity.IsActive = true;
                    }
                    else if(e.State == EntityState.Modified )
                    {
                        var entity = e.Entity as BaseEntity;
                        entity.UpdatedOn = DateTime.UtcNow;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
