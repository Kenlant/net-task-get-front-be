using NetTaskGetFront.Core.Models.Processors;

namespace NetTaskGetFront.Core.Requests.Stock.Commands.Get
{
    public class GetStockViewModel
    {
        public IEnumerable<StockPerfomance> StockPerfomance { get; set; }
    }
}
