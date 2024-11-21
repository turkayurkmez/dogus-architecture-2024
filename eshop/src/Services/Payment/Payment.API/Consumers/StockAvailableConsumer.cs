using eshop.MessageBus;
using MassTransit;

namespace Payment.API.Consumers
{
    public class StockAvailableConsumer(ILogger<StockAvailableConsumer> logger, IPublishEndpoint endpoint) : IConsumer<StockAvailableEvent>
    {
        public async Task Consume(ConsumeContext<StockAvailableEvent> context)
        {
            var command = context.Message.StockAvailableCommand;

            if (isPaymentCompleted(command.CreditCardInfo))
            {
                var @event = new PaymentSuccessEvent() { PaymentSucceededCommand = new PaymentSucceededCommand(command.OrderId, command.CustomerId) };

                await endpoint.Publish(@event);
                logger.LogInformation($"Ödeme başarılı...{command.TotalPrice} ödendi ");

            }
            else
            {
                var @event = new PaymentFailedEvent() { PaymentFailedCommand = new PaymentFailedCommand(command.OrderId, command.CustomerId, "Kredi kartı tarihi hatalı") };
                await endpoint.Publish(@event);
                logger.LogInformation($"Ödeme alınamadı");
            }
        }

        private bool isPaymentCompleted(string creditCardInfo)
        {
            return new Random().Next(1,1000) % 2 == 0;
        }
    }

}
