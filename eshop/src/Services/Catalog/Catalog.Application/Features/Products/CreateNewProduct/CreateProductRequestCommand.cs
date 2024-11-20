using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.CreateNewProduct
{
    public record CreateProductRequestCommand([Required(ErrorMessage ="Dolu olmalı")] string Name, 
                                              [Required] string Description, 
                                              decimal? Price, 
                                              string? ImageUrl): IRequest<int>;

    
}
