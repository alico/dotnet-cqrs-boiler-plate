using CQRS.Boilerplate.Application.Commands;
using CQRS.Boilerplate.Application.Customer.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Boilerplate.API.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(ILogger<CustomerController> logger, IMediator mediator) : base(logger, mediator)
        {

        }

        /// <summary>
        /// Places order
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(PlaceOrderResponse),StatusCodes.Status200OK)]
        public async Task<ActionResult<PlaceOrderResponse>> Get(CancellationToken cancellationToken)
        {
            var requestModel = new PlaceOrderRequest();
            var command = new CreateCustomerCommand()
            {
                Name = "Test",
                Email = $"{new Random().Next(1000, 10000)}@email.com",
            };

            var customerId = await _mediator.Send(command, cancellationToken);
            var response = new AddNewCustomerResponse()
            {
                Id = customerId
            };

            return Created(string.Empty, response);
        }
    }
}