using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.DiscountProductPrice
{
    public record DiscountProductPriceCommand(int Id, decimal Discount) : IRequest<DiscountProductPriceResponse>;
    public record DiscountProductPriceResponse(int Id, decimal? OldPrice, decimal? NewPrice);

    
}
