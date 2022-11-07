using NetTaskGetFront.Core.Enums;
using NetTaskGetFront.Core.Models.Services.StockService;

namespace NetTaskGetFront.Core.Interfaces.Services
{
    public interface IStockService
    {
        Task<StockData> Get(string ticker, TimePeriod period, DateTimeOffset startDate, DateTimeOffset endDate);
    }
}
