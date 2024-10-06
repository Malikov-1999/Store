using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Data.Models;

namespace Store.Data
{
    public class AppDBContent : IdentityDbContext<ApplicationUser>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка отношений между Product и Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Настройка отношений между Product и Variation
            modelBuilder.Entity<Variation>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Variations)
                .HasForeignKey(v => v.ProductId);

            // Настройка отношений между Product и Detail
            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.Details)
                .HasForeignKey(d => d.ProductId);

            // Настройка отношений между Product и Image
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId);





        }

    }
}