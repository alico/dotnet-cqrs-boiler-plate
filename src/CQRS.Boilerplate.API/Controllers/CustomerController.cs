using AutoMapper;
using CQRS.Boilerplate.Application.Commands;
using CQRS.Boilerplate.Application.Customer.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Boilerplate.API.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(ILogger<CustomerController> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
        {

        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCustomerResponse>> Put(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateCustomerCommand>(request);
            var customerId = await _mediator.Send(command, cancellationToken);
            var response = new CreateCustomerResponse()
            {
                Id = customerId
            };

            return Created(string.Empty, response);
        }
    }
}