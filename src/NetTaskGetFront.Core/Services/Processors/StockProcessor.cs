using NetTaskGetFront.Core.Interfaces.Processors;
using NetTaskGetFront.Core.Models.Processors;
using NetTaskGetFront.Domain.Entities;

namespace NetTaskGetFront.Core.Services.Processors
{
    public class StockProcessor : IStockProcessor
    {
        public async Task<IEnumerable<StockPerfomance>> CalculatePerfomanceAsync(IEnumerable<Stock> data)
        {
            if (data == null) return new List<StockPerfomance>();

            var groups = data.GroupBy(x => x.Ticker)
                .Select(x => new StockPerfomance
                {
                    Ticker = x.Key,
                    Items = CalculatePerfomanceForGroup(x)
                })
                .ToList();

            return groups;
        }

        private IEnumerable<StockPerfomanceItem> CalculatePerfomanceForGroup(IEnumerable<Stock> stocks)
        {
            var orderedItems = stocks.OrderBy(x => x.Timestamp);
            var firstItem = orderedItems.FirstOrDefault();

            var result = orderedItems
                .Select(x => new StockPerfomanceItem
                {
                    Time = x.Timestamp,
                    Perfomance = (float)(x.Price / firstItem.Price) - 1
                }).ToList();

            return result;
        }
    }
}
