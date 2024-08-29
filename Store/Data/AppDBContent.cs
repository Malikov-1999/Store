using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Data.Models;

namespace Store.Data
{
    public class AppDBContent : IdentityDbContext<ApplicationUser>  // Измените здесь на ApplicationUser
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<ProductSizePrice> ProductSizePrices { get; set; }

    }
}
