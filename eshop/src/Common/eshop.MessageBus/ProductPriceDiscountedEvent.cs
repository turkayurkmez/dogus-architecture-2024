using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{

    /*
     *  Producer: Catalog.API 
     *  Consumer(s): Basket.API ve Order.API
     */
    public class ProductPriceDiscountedEvent
    {
        public ProductPriceDiscountCommand ProductPriceDiscountCommand { get; set; }
    }

    public record ProductPriceDiscountCommand(int ProductId, decimal? OldPrice, decimal? NewPrice, decimal? Discount);



}
