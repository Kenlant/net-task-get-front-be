using NetTaskGetFront.Core.Interfaces.Services;
using NetTaskGetFront.Domain.Entities;
using NetTaskGetFront.Domain.Enums;

namespace NetTaskGetFront.PolygonStockService
{
    public class PoligonStockService : IStockService
    {
        private readonly IPoligonHttpClient _client;

        public PoligonStockService(IPoligonHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Stock>> GetAsync(string ticker, TimePeriod period, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var from = startDate.ToString("yyyy-MM-dd");
            var to = endDate.ToString("yyyy-MM-dd");
            var multiplier = 1;
            var periodString = period.ToString().ToLower();
            
            var response = await _client.GetAggregated(ticker, multiplier, periodString, from, to);

            var result = response.Results
                .Select(x => new Stock
                {
                    Price = x.OpenPrice,
                    Ticker = response.Ticker,
                    Timeperiod = period,
                    Timestamp = x.Time
                })
                .ToList();

            return result;
        }
    }
}
