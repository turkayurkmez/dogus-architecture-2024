using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        // TODO 1: Image bilgisini Record olarak kullan. 

        public void ChangePrice(decimal price)
        {

            Price = price;
        }

    }

   
}
