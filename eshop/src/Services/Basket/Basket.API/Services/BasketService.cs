using Basket.API.Protos;
using Grpc.Core;

namespace Basket.API.Services
{
    public class BasketService(ILogger<BasketService> logger): Protos.Basket.BasketBase 
    {
        public override async Task<AddToBasketResponse> AddToBasket(AddToBasketRequest request, ServerCallContext context)
        {
            logger.LogInformation("Grpc fonksiyonu çalıştı");

            logger.LogInformation($"Gelen talep: {request.Items.Count}");

            logger.LogInformation($"Gelen talepteki ürünler: {string.Join(",", request.Items.Select(x => x.ProductId.ToString()))}");

            var response = new AddToBasketResponse();
            var customerBasket = MapToCustomerBasket("anonym", request);
            //repository.AddToBasket(customerBasket);
            foreach (var item in request.Items)
            {
                response.Items.Add(item);   
            }

           
            return await Task.FromResult(response);
        }

        private CustomerBasket MapToCustomerBasket(string userName, AddToBasketRequest request)
        {
            var response = new CustomerBasket
            {
                CustomerId = userName,
                Items = new List<BasketItem>()
            };

            foreach (var item in request.Items)
            {
                response.Items.Add(new() { ProductId = item.ProductId, Quantity = item.Quantity });
            }
            return response;
        }

    }
}
