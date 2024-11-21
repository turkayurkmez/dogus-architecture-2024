using eshop.MessageBus;
using MassTransit;
using Order.API.Consumers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<ProductPriceDiscountedConsumer>();
    config.AddConsumer<PaymentEventConsumer>();
    config.AddConsumer<StockFailedConsumer>();

    config.UsingRabbitMq((context, factoryConfig) =>
    {
        factoryConfig.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        factoryConfig.ReceiveEndpoint(nameof(ProductPriceDiscountedEvent), c => c.ConfigureConsumer<ProductPriceDiscountedConsumer>(context));
        factoryConfig.ConfigureEndpoints(context);
    });




});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/orderCreate", async (IPublishEndpoint publishEndpoint, OrderCreateRequest request) =>
{

    //db'ye eklendi!
    var @event = new OrderCreatedEvent();
    var orderId = new Random().Next(1000, 5000);
    var orderItems = request.OrderItems.Select(oi => new OrderItem(oi.ProductId, oi.Quantity, oi.Price));
    var eventCommand = new OrderCreatedCommand(orderId, request.CustomerId, request.CreditCardInfo, orderItems );
    @event.OrderCreatedCommand = eventCommand;

    await publishEndpoint.Publish(@event);
    app.Logger.LogInformation("Sipariş oluşturuldu");
});


app.Run();


public record OrderCreateRequest
{
    public int CustomerId { get; set; }
    public string CreditCardInfo { get; set; }
    public List<OrderItemInRequest> OrderItems { get; set; }
}

public record OrderItemInRequest(int ProductId, int Quantity, decimal? Price);



