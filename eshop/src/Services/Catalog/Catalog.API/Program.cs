﻿using Catalog.Application.Contracts;
using Catalog.Application.Features.Products.GetAllProducts;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("db");

var host = builder.Configuration.GetSection("Host").Value;
var pass = builder.Configuration.GetSection("Pass").Value;


connectionString = connectionString.Replace("[HOST]", host)
                                   .Replace("[PASS]", pass);



builder.Services.AddDbContext<DogusEshopDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddMassTransit(config =>
{
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

app.Logger.LogInformation($"---- Bağlantı bilgisi :{connectionString}");

using var scope  = app.Services.CreateScope();
var db =  scope.ServiceProvider.GetRequiredService<DogusEshopDbContext>();
db.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
    //test Fixture olarak bu tipe erişebilmek için isim belirttik
}