using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class DogusEshopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DogusEshopDbContext(DbContextOptions<DogusEshopDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                  new Product(1,"P1","P1 Açıklaması",1, "https://placehold.co/400"),
                  new Product(2, "P2", "P2 Açıklaması", 1, "https://placehold.co/400"),
                  new Product(3, "P3", "P3 Açıklaması", 1, "https://placehold.co/400"),
                  new Product(4, "P4", "P4 Açıklaması", 1, "https://placehold.co/400")

                );
        }
    }
}
