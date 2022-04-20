using AutoMapper;
using CQRS.Boilerplate.Application.Commands;
using CQRS.Boilerplate.Application.Customer.Commands;
using CQRS.Boilerplate.Application.Order.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Boilerplate.API.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(ILogger<CustomerController> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
        {

        }

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(PlaceOrderResponse),StatusCodes.Status200OK)]
        public async Task<ActionResult<PlaceOrderResponse>> Get(PlaceOrderRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<PlaceOrderCommand>(request);
            var orderId = await _mediator.Send(command, cancellationToken);
            var response = new PlaceOrderResponse()
            {
                Id = orderId
            };

            return Created(string.Empty, response);
        }
    }
}