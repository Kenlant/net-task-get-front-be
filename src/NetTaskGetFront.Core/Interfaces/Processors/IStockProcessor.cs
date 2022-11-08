using NetTaskGetFront.Core.Models.Processors;
using NetTaskGetFront.Domain.Entities;

namespace NetTaskGetFront.Core.Interfaces.Processors
{
    public interface IStockProcessor
    {
        Task<IEnumerable<StockPerfomance>> CalculatePerfomanceAsync(IEnumerable<Stock> data, CancellationToken cancellationToken = default);
    }
}
