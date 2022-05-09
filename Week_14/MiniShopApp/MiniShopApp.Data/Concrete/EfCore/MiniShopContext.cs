using Microsoft.EntityFrameworkCore;
using MiniShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Concrete.EfCore
{
    public class MiniShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MiniShopAppDb"); //veritabanı bağlantısını sağlanması varsa yoksa yeniden oluştur.
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()   //product categori unique olması için aynı kayıt tekrar girilmesin istiyoruz.
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });
        }
    }
}
