using CQRS.Boilerplate.Application.Commands;
using CQRS.Boilerplate.Application.Product.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Boilerplate.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILogger<ProductController> logger, IMediator mediator) : base(logger, mediator)
        {

        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(AddNewProductResponse),StatusCodes.Status200OK)]
        public async Task<ActionResult<AddNewProductResponse>> Get(CancellationToken cancellationToken)
        {
            AddNewProductRequest requestModel = new AddNewProductRequest();
            var command = new CreateProductCommand()
            {
                Name = "Test",
                Quantity = new Random().Next(1, 10),
                SKU = new Random().Next(1000, 10000).ToString(),
            };

            var productId = await _mediator.Send(command, cancellationToken);
            var response = new AddNewProductResponse()
            {
                Id = productId
            };

            return Created(string.Empty, response);
        }
    }
}