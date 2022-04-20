using AutoMapper;
using CQRS.Boilerplate.Application.Commands;
using CQRS.Boilerplate.Application.Common.Models;
using CQRS.Boilerplate.Application.Product.Commands;
using CQRS.Boilerplate.Application.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Boilerplate.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILogger<ProductController> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
        {

        }

        /// <summary>
        /// Gets all products with pagination
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pageNumber}/{pageSize}")]
        [ProducesResponseType(typeof(PaginatedListResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedListResponse<ProductDto>>> Get(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetProductsQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query, cancellationToken);
            var response = new PaginatedListResponse<ProductDto>()
            {
                Items = result.Items
            };

            return Ok(response);
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CreateProductResponse),StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateProductResponse>> Put(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateProductCommand>(request);
            var productId = await _mediator.Send(command, cancellationToken);
            var response = new CreateProductResponse()
            {
                Id = productId
            };

            return Created(string.Empty, response);
        }
    }
}