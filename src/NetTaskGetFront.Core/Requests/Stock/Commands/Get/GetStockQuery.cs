using NetTaskGetFront.Core.Enums;
using NetTaskGetFront.Core.Infrastracture.Interfaces;

namespace NetTaskGetFront.Core.Requests.Stock.Commands.Get
{
    public class GetStockQuery: IHandleableRequest<GetStockQuery, GetStockQueryHandler, GetStockViewModel>
    {
        public string Ticker { get; set; }
        public TimePeriod Period { get; set; }
    }
}
