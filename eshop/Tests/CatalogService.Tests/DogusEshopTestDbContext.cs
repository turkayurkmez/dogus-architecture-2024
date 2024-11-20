using Catalog.Domain;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Tests
{
    public class DogusEshopTestDbContext : DogusEshopDbContext
    {
        public DogusEshopTestDbContext(DbContextOptions<DogusEshopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            using (StreamReader reader = new StreamReader("../../../Data/products.json"))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<dynamic[]>(json);
                var products = new List<Product>();
                foreach (dynamic item in data)
                {
                    products.Add(new Product(item.Id, item.Name,item.Description,item.Price,item.ImageUrl));
                }

                modelBuilder.Entity<Product>().HasData(products);
            }
        }
    }
}
