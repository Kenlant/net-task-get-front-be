using NetTaskGetFront.Core.Enums;
using NetTaskGetFront.Core.Interfaces.Services;
using NetTaskGetFront.Core.Models.Services.StockService;

namespace NetTaskGetFront.PolygonStockService
{
    public class PoligonStockService : IStockService
    {
        private readonly IPoligonHttpClient _client;

        public PoligonStockService(IPoligonHttpClient client)
        {
            _client = client;
        }

        public async Task<StockData> Get(string ticker, TimePeriod period, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var from = startDate.ToString("yyyy-MM-dd");
            var to = endDate.ToString("yyyy-MM-dd");
            var multiplier = 1;
            var periodString = period.ToString().ToLower();
            
            var response = await _client.GetAggregated(ticker, multiplier, periodString, from, to);

            var result = new StockData
            {
                Ticker = response.Ticker,
                StockPeriodData = response.Results
                    .Select(x => new StockPeriodData
                    {
                        Price = x.OpenPrice,
                        Time = x.Time,
                        Period = period
                    })
                    .ToList()
            };

            return result;
        }
    }
}
