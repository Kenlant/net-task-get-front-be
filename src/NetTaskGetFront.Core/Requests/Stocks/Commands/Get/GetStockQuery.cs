using NetTaskGetFront.Core.Infrastracture.Interfaces;
using NetTaskGetFront.Domain.Enums;

namespace NetTaskGetFront.Core.Requests.Stocks.Commands.Get
{
    public class GetStockQuery: IHandleableRequest<GetStockQuery, GetStockQueryHandler, GetStockViewModel>
    {
        public string Ticker { get; set; }
        public TimePeriod Period { get; set; }
    }
}
