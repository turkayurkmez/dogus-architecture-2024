using Catalog.Application.Contracts;
using Catalog.Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.CreateNewProduct
{
    public class CreateProductRequestCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductRequestCommand, int>
    {
        public async Task<int> Handle(CreateProductRequestCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await productRepository.CreateAsync(product);
            return product.Id;
        }
    }
}
