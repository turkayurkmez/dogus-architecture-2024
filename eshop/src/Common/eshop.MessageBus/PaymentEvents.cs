using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public record PaymentSuccessEvent {

        public PaymentSucceededCommand PaymentSucceededCommand { get; set; }

    }
    
    public record PaymentSucceededCommand(int OrderId, int CustomerId);

    public record PaymentFailedEvent {
        public PaymentFailedCommand PaymentFailedCommand { get; set; }
    }
    public record PaymentFailedCommand(int OrderId, int CustomerId, string Reason);
    
}
