using Catalog.Application.Contracts;
using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services
{
    public class ProductService(IProductRepository productRepository)
    {
        /*
         * Gelecekte Product entity'si ile her iş veya use case'de buraya fonksiyon yazacaksınız.
         * 
         * Acaba bunun yerine yeni her iş ya da use case, yeni bir sınıf olarak yazılsa?
         */
        //async Task<IEnumerable<Product>> GetProducts()
        //{
        //    return await productRepository.GetAllAsync();
        //}

        //async Task DiscountPrice(int id, decimal discount)
        //{
        //    var product = await productRepository.FindAsync(id);
        //    product.ChangePrice(product.Price!.Value * (1-discount));

        //}
    }
}
