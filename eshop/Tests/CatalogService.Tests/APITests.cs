using Catalog.Application.Features.Products.CreateNewProduct;
using Catalog.Application.Features.Products.GetAllProducts;
using Catalog.Application.Features.Products.GetProductById;
using CatalogService.Tests.FixtureComponents;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CatalogService.Tests
{
    public class APITests : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private readonly InMemoryWebApplicationFactory<Program> applicationFactory;

        public APITests(InMemoryWebApplicationFactory<Program> applicationFactory)
        {
            this.applicationFactory = applicationFactory;
        }
        [Fact]
        public async Task web_api_get_request_return_ok_object_result()
        {
            var client = applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/products");
            var output = await response.Content.ReadAsStringAsync();
            var productsResponse = JsonConvert.DeserializeObject<GetAllProductsResponse>(output);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(7, productsResponse.products.Count());
        }

        [Fact]
        public async Task web_api_post_request()
        {
            var client = applicationFactory.CreateClient();
            var command = new CreateProductRequestCommand("Product X", "X Açıklama", 25, "test");
            var httpContent = new StringContent(JsonConvert.SerializeObject(command),Encoding.UTF8,"application/json");

            var response = await client.PostAsync("/api/products", httpContent);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Headers.Location.Should().NotBeNull();
            //Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            //Assert.NotNull(response.Headers.Location);
        }

        [Fact]
        public async Task get_product_by_id()
        {
            var client = applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/products/1");
            var output = await response.Content.ReadAsStringAsync();
            var productResponse = JsonConvert.DeserializeObject<GetProductByIdResponse>(output);

            productResponse.Should().NotBeNull();
            productResponse.Name.Should().Be("P1");
        }
    }
}