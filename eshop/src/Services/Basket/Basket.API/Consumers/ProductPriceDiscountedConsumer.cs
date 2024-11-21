using eshop.MessageBus;
using MassTransit;

namespace Basket.API.Consumers
{
    public class ProductPriceDiscountedConsumer(ILogger<ProductPriceDiscountedConsumer> logger) : IConsumer<ProductPriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {
            var command = context.Message.ProductPriceDiscountCommand;
            logger.LogInformation($"{command.ProductId} id'li ürünün eski fiyatı {command.OldPrice} TL, yeni fiyatı ise {command.NewPrice} ");

            return Task.CompletedTask;

        }
    }
}
