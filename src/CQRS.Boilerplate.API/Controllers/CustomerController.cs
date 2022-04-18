using CQRS.Boilerplate.Application.Commands;
using CQRS.Boilerplate.Application.Customer.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Boilerplate.API.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(ILogger<CustomerController> logger, IMediator mediator) : base(logger, mediator)
        {

        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(AddNewCustomerResponse),StatusCodes.Status200OK)]
        public async Task<ActionResult<AddNewCustomerResponse>> Get(CancellationToken cancellationToken)
        {
            var requestModel = new AddNewCustomerRequest();
            var command = new CreateCustomerCommand()
            {
                Name = "Test",
                Email = $"{new Random().Next(1000, 10000).ToString()}@email.com",
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