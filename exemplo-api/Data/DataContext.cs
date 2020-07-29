using exemplo_api.Models;
using Microsoft.EntityFrameworkCore;

namespace exemplo_api.Data
{
    public class DataContext : DbContext
    {
         public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseMySql("server=127.0.0.1;userid=root;password=456852;database=SGM_Cidadao"));                        
        }
    }
}
