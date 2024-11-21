using eshop.MessageBus;
using MassTransit;

namespace Order.API.Consumers
{
    public class PaymentEventConsumer(ILogger<PaymentEventConsumer> logger) : 
                                     IConsumer<PaymentFailedEvent>, 
                                     IConsumer<PaymentSuccessEvent>
    {
        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            var command = context.Message.PaymentFailedCommand;
            logger.LogInformation($"{command.OrderId} id'li sipariş reddedildi. Sebebi: {command.Reason}");
          
            return Task.CompletedTask;
        }

        public Task Consume(ConsumeContext<PaymentSuccessEvent> context)
        {
            var command = context.Message.PaymentSucceededCommand;
            logger.LogInformation($"{command.OrderId} id'li sipariş onaylandı.");

            return Task.CompletedTask;

        }
    }
}
