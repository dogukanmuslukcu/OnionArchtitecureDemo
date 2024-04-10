using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Commands;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Application.Interfaces.Repository;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> Getall() 
        {
            var query = new GetAllProductQuery();
            return Ok(await mediator.Send(query));
        }
        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct(CreateProductCommand productCommand)
        {
            return Ok(await mediator.Send(productCommand));
        }

        [HttpGet("getproductbyıd")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery() {Id = id };
            return Ok(await mediator.Send(query));
        }
    }
}
