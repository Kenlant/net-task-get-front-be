using Microsoft.AspNetCore.Mvc;
using NetTaskGetFront.Core.Requests.Test.Get;
using NetTaskGetFront.Web.Infrastracture.Controllers;

namespace NetTaskGetFront.Web.Controllers
{
    public class TestController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get([FromQuery] GetTestDataQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("exception/{type?}")]
        public async Task<ActionResult> Exception(string type)
        {
            var ex = type switch
            {
                _ => new Exception("test application exception")
            };

            throw ex;
        }
    }
}
