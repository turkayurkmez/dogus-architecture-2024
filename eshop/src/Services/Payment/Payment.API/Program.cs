using MassTransit;
using Payment.API.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<StockAvailableConsumer>();
    config.UsingRabbitMq((context, factoryConfig) =>
    {
        factoryConfig.Host("rabbit-mq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });


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

//app.UseHttpsRedirection();



app.Run();

