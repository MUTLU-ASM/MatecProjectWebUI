using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<UnitType> unitTypes { get; set; }

        // protected tanımı o değere, bulunduğu class  ve ondan türetilen diğer sınıflar içinden erişilebilir olduğunu göstermektedir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SBTQ48V\\SQLEXPRESS;initial catalog=MatecProjectDb;integrated security=true;");
        }
    }
}
