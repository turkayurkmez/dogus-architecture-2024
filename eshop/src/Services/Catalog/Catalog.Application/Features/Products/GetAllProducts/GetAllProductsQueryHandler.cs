using Catalog.Application.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        //public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery query)
        //{
        //    var products = await productRepository.GetAllAsync();
        //    var productResponse = products.Select(p => new ProductCardDisplay(Id: p.Id, Name: p.Name, Description: p.Description, Price: p.Price, ImageUrl: p.ImageInfo?.ImageUrl));
        //    var response = new GetAllProductsResponse(productResponse);

        //    return response;
        //}

        //public async Task<object> Handle(object query)
        //{
        //    return Task.CompletedTask;

        //}
        public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            //var productResponse = products.Select(p => new ProductCardDisplay(
            //    Id: p.Id,
            //    Name: p.Name,
            //    Description: p.Description,
            //    Price: p.Price,
            //    ImageUrl: p.ImageInfo?.ImageUrl));


            var productResponse = products.Adapt<IEnumerable<ProductCardDisplay>>();
            var response = new GetAllProductsResponse(productResponse, Info:$"Toplam ürün sayısı: {productResponse.Count()}");

            return response;
        }
    }
}
