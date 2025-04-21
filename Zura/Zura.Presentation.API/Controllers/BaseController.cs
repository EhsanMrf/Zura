using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zura.Presentation.API.Filter;

namespace Zura.Presentation.API.Controllers
{
    [Route("[controller]"), CatchExceptionFilter, ApiController]
    public abstract class BaseController : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
