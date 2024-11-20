using Catalog.Application.Features.Products.GetAllProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.SearchByName
{
    public record SearchByNameQuery(string Name) : IRequest<SearchProductsByNameResponse>;
    
    public record ProductListDisplay(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
    public record SearchProductsByNameResponse(IEnumerable<ProductListDisplay> Results, string State);




}
