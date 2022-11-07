using Microsoft.AspNetCore.Mvc;
using NetTaskGetFront.Core.Requests.Stock.Commands.Get;
using NetTaskGetFront.Web.Infrastracture.Controllers;

namespace NetTaskGetFront.Web.Controllers
{
    public class StockController: BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<GetStockViewModel>> Get([FromQuery]GetStockQuery request,
            CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}
