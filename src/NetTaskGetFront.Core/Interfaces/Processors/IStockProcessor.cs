using NetTaskGetFront.Core.Models.Processors;
using NetTaskGetFront.Core.Models.Services.StockService;

namespace NetTaskGetFront.Core.Interfaces.Processors
{
    public interface IStockProcessor
    {
        Task<StockPerfomance> CalculatePerfomance(StockData data);
    }
}
