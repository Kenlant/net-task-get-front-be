using NetTaskGetFront.Core.Models.Services.StockService;

namespace NetTaskGetFront.Core.Models.Processors
{
    public class StockPerfomance
    {
        public string Ticker { get; set; }
        public IEnumerable<StockPerfomanceItem> Items { get; set; }
    }
}
