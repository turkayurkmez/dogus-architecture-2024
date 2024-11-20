using Catalog.Application.Contracts;
using Catalog.Application.Features.Products.GetAllProducts;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<DogusEshopDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
//using var scope  = app.Services.CreateScope();
//var db =  scope.ServiceProvider.GetRequiredService<DogusEshopDbContext>();
//db.Database.Migrate();

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