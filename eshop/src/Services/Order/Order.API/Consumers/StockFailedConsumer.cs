using eshop.MessageBus;
using MassTransit;

namespace Order.API.Consumers
{
    public class StockFailedConsumer(ILogger<StockFailedConsumer> logger) : IConsumer<StockNotAvailableEvent>
    {
        public Task Consume(ConsumeContext<StockNotAvailableEvent> context)
        {
            var command = context.Message.StockNotAvailableCommand;
            logger.LogInformation($"{command.OrderId}, stok yetersizlği nedeniyle reddedildi ");
            return Task.CompletedTask;
        }
    }
}
