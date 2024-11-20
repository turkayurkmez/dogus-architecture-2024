using Basket.API.Protos;

namespace Basket.API.Services
{
    internal class CustomerBasket
    {
        public string CustomerId { get; internal set; }
        public List<BasketItem> Items { get; internal set; }
    }
}