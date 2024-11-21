using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public record StockAvailableEvent
    {
        public StockAvailableCommand StockAvailableCommand { get; set; }
    }

    public record StockAvailableCommand(int OrderId, int CustomerId, string CreditCardInfo, decimal? TotalPrice);



    public record StockNotAvailableEvent
    {
        public StockNotAvailableCommand StockNotAvailableCommand { get; set; }
    }
    public record StockNotAvailableCommand(int OrderId);

}
