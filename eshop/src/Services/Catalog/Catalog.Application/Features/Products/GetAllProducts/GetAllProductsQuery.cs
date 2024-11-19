using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.GetAllProducts
{
    //İstemcinin üründen talep ettiği özellikler:
    public record ProductCardDisplay(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    //Sunucunun vereceği yanıt:
    public record GetAllProductsResponse(IEnumerable<ProductCardDisplay> products, string Info);

    //İstemcinin sunucuya göndereceği istek:

    public record GetAllProductsQuery():IRequest<GetAllProductsResponse>;


}
