using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NetTaskGetFront.Web.Infrastracture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController: ControllerBase
    {
        private IMediator _mediator;

        public IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetRequiredService<IMediator>());
    }
}
