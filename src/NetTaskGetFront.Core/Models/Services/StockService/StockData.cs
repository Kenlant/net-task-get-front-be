namespace NetTaskGetFront.Core.Models.Services.StockService
{
    public class StockData
    {
        public string Ticker { get; set; }
        public IEnumerable<StockPeriodData> StockPeriodData { get; set; }
    }
}
