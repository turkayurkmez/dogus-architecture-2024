using Basket.API.Consumers;
using Basket.API.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<ProductPriceDiscountedConsumer>();
    config.UsingRabbitMq((context, factoryConfig) =>
    {
        factoryConfig.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        factoryConfig.ConfigureEndpoints(context);
    });




});
var app = builder.Build();

app.MapGrpcService<BasketService>();
app.MapGet("/basket", () => "Basket grpc ayakta!");
app.Run();