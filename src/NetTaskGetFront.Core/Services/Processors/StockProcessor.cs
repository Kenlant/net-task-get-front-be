using NetTaskGetFront.Core.Interfaces.Processors;
using NetTaskGetFront.Core.Models.Processors;
using NetTaskGetFront.Core.Models.Services.StockService;

namespace NetTaskGetFront.Core.Services.Processors
{
    public class StockProcessor : IStockProcessor
    {
        public async Task<StockPerfomance> CalculatePerfomance(StockData data)
        {
            var result = new StockPerfomance() { Ticker = data.Ticker };

            if (!data.StockPeriodData.Any())
            {
                result.Items = new List<StockPerfomanceItem>();
                return result;
            }

            var orderedItems = data.StockPeriodData.OrderBy(x => x.Time);
            var firstItem = orderedItems.FirstOrDefault();

            result.Items = orderedItems
                .Select(x => new StockPerfomanceItem
                {
                    Time = x.Time,
                    Perfomance = (float)(x.Price / firstItem.Price) - 1
                }).ToList();

            return result;
        }
    }
}
