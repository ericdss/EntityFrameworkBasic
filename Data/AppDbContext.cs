using Microsoft.EntityFrameworkCore;
using EntityFrameworkBasic.Models.Entities;

namespace EntityFrameworkBasic.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Product> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;userid=developer;password=1234;database=EFBasic;");
        }

    }
}