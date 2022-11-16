using NetTaskGetFront.Core.Interfaces.Repositories.Base;
using NetTaskGetFront.Domain.Entities;

namespace NetTaskGetFront.Core.Interfaces.Repositories
{
    public interface IStockRepository: IRepository<Stock>
    {
        Task<IEnumerable<Stock>> GetListAsync(string ticker, long from, long to, CancellationToken cancellationToken = default);
    }
}
