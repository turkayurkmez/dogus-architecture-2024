using Catalog.Application.Contracts;
using Catalog.Domain;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repository
{
    public class ProductRepository(DogusEshopDbContext dbContext) : IProductRepository
    {

        public async Task CreateAsync(Product entity)
        {
            dbContext.Products.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
         
            var entity = await dbContext.Products.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == id);
            dbContext.Products.Remove(entity);  
            await dbContext.SaveChangesAsync();
   
        }

        public async Task<Product> FindAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByName(string name)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
