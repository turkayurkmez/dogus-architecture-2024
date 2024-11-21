using Catalog.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.DiscountProductPrice
{
    internal class DiscountProductPriceCommandHandler(IProductRepository repository) : IRequestHandler<DiscountProductPriceCommand, DiscountProductPriceResponse>
    {
        public async Task<DiscountProductPriceResponse> Handle(DiscountProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.FindAsync(request.Id);
            var oldPrice = product.Price;
            var newPrice = product.Price * (1 - request.Discount);
            product.ChangePrice(newPrice);

            await repository.UpdateAsync(product);
            var response = new DiscountProductPriceResponse(product.Id, oldPrice, newPrice);
            return response;


        }
    }
}
