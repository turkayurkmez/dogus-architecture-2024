using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    public class Product : IEntity
    {
        public Product()
        {
                
        }

        public Product(int id, string name, string? description, decimal? price, string? imageUrl )
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;

        }
        public int Id { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal? Price { get; private set; }

        // TODO 1: Image bilgisini Record olarak kullan. 
  
        public string? ImageUrl { get; set; }
      
        public int? Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public void ChangePrice(decimal price)
        {

            Price = price;
        }

    }


}
