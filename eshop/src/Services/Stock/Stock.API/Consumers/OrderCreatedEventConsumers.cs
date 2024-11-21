using eshop.MessageBus;
using MassTransit;

namespace Stock.API.Consumers
{
    public class OrderCreatedEventConsumers(ILogger<OrderCreatedEventConsumers> logger, IPublishEndpoint publishEndpoint) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var command = context.Message.OrderCreatedCommand;

            bool isStockAvailable = checkStock(command.OrderItems);

            if (isStockAvailable)
            {
                var @event = new StockAvailableEvent();
                var totalPrice = getTotalPrice(command.OrderItems);
                var availableCommand = new StockAvailableCommand(command.OrderId, command.CustomerId, command.CreditCardInfo, totalPrice);

                @event.StockAvailableCommand = availableCommand;
                await publishEndpoint.Publish(@event);

                logger.LogInformation("Stok uygun. Uygun olayı fırladı");


            }
            else
            {
                var @event = new StockNotAvailableEvent() { StockNotAvailableCommand = new StockNotAvailableCommand(command.OrderId) };
                await publishEndpoint.Publish(@event);
                logger.LogInformation("Stok uygun değil.... İlgili olay fırlatıldı....");
            }

        }

        private decimal? getTotalPrice(IEnumerable<OrderItem> orderItems)
        {
            return orderItems.Sum(o => o.Price * o.Quantity);
        }

        private bool checkStock(IEnumerable<OrderItem> orderItems)
        {
            return Convert.ToBoolean(new Random().Next(0, 2));
        }
    }
}
