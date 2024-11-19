using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdResponse>;

    public record GetProductByIdResponse(int Id, string Name, string? Description, decimal? Price, string? ImageUrl);
}
