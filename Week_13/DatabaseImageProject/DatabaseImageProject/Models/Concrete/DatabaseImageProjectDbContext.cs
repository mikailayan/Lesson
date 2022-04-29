using DatabaseImageProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseImageProject.Models.Concrete
{
    public class DatabaseImageProjectDbContext : DbContext
    {
        public DatabaseImageProjectDbContext()
        {

        }
        public DatabaseImageProjectDbContext(DbContextOptions<DatabaseImageProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CKAIKM6; Database=ImageProject; Trusted_Connection=true;");
        }
    }
}
