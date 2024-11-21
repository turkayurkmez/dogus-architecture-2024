using eshop.MessageBus;
using MassTransit;

namespace Order.API.Consumers
{
    public class ProductPriceDiscountedConsumer(ILogger<ProductPriceDiscountedConsumer> logger) :
        IConsumer<ProductPriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {
            var message = context.Message;
            var command = message.ProductPriceDiscountCommand;

            logger.LogInformation($"{command.ProductId} id'li ürünün yeni fiyatı {command.NewPrice} oldu. Toplam {command.OldPrice - command.NewPrice} TL'lik indirim yansıtıldı ");
            return Task.CompletedTask;
        }
    }
}
