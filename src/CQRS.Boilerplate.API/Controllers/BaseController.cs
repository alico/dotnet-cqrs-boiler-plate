using CQRS.Boilerplate.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Boilerplate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
    }
}