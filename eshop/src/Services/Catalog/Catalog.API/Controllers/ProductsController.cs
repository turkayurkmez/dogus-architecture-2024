
using Catalog.Application.Features.Products.CreateNewProduct;
using Catalog.Application.Features.Products.DiscountProductPrice;
using Catalog.Application.Features.Products.GetAllProducts;
using Catalog.Application.Features.Products.GetProductById;
using Catalog.Application.Features.Products.SearchByName;
using eshop.MessageBus;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetProductByIdQuery(id);
            var response = await mediator.Send(query);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Search(string name)
        {
            var query = new SearchByNameQuery(name);
            var response = await mediator.Send(query);
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<IActionResult> Create(CreateProductRequestCommand requst)
        {
            if (ModelState.IsValid)
            {
                var lastProductID = await mediator.Send(requst);
                return CreatedAtAction(nameof(Get), routeValues: new { id = lastProductID }, null);

            }
            return BadRequest();
        }


        // TODO 2: Ürün fiyatını düşüren action yaz! 
        [HttpPut("discount/{id:int}")]
        public async Task<IActionResult> DiscountPrice(int id, DiscountProductPriceCommand request)
        {

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(request);
                var @event = new ProductPriceDiscountedEvent
                {
                    ProductPriceDiscountCommand = new ProductPriceDiscountCommand(response.Id, response.OldPrice, response.NewPrice, request.Discount)
                };
                await publishEndpoint.Publish(@event);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
