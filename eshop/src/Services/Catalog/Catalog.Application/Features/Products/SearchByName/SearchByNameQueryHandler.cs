using Catalog.Application.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.SearchByName
{
    public class SearchByNameQueryHandler(IProductRepository repository) : IRequestHandler<SearchByNameQuery, SearchProductsByNameResponse>
    {
        public async Task<SearchProductsByNameResponse> Handle(SearchByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.SearchByName(request.Name);
            var searchedResult = products.Adapt<IEnumerable<ProductListDisplay>>();
            var message = searchedResult.Count() > 0 ? $"{searchedResult.Count()} adet veri oluştu" : $" {request.Name} isminde ürün bulunamadı";
            var response = new SearchProductsByNameResponse(searchedResult, message);
            return response;
        }
    }
}
