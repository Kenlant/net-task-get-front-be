using NetTaskGetFront.Domain.Entities;
using NetTaskGetFront.Domain.Enums;

namespace NetTaskGetFront.Core.Interfaces.Services
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAsync(string ticker, TimePeriod period, DateTimeOffset startDate, DateTimeOffset endDate);
    }
}
