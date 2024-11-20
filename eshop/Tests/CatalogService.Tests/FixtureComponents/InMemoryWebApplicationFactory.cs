using Catalog.Application.Contracts;
using Catalog.Application.Features.Products.GetAllProducts;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Tests.FixtureComponents
{
    public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                   .ConfigureTestServices(services =>
                   {
                       var options = new DbContextOptionsBuilder<DogusEshopDbContext>()
                                         .UseInMemoryDatabase("testMemory")
                                         .Options;

                       services.AddScoped<DogusEshopDbContext>(provider =>new DogusEshopTestDbContext(options));

                       services.AddScoped<IProductRepository, ProductRepository>();

                       services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>());

                      
                       var sProvider = services.BuildServiceProvider();
                       using var scoped = sProvider.CreateScope();
                       var db = scoped.ServiceProvider.GetRequiredService<DogusEshopDbContext>();
                       db.Database.EnsureCreated();
                       


                   });
        }
    }
}
