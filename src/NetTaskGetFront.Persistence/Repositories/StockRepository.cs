using Microsoft.EntityFrameworkCore;
using NetTaskGetFront.Core.Interfaces.Repositories;
using NetTaskGetFront.Domain.Entities;
using NetTaskGetFront.Persistence.Repositories.Base;

namespace NetTaskGetFront.Persistence.Repositories
{
    public class StockRepository: Repository<Stock>, IStockRepository
    {
        public StockRepository(NetTaskGetFrontDbContext context)
            :base(context)
        {

        }

        public async Task<IEnumerable<Stock>> GetListAsync(string ticker, long from, long to, CancellationToken cancellationToken = default)
        {
            return await Context.Stocks
                .Where(x => x.Ticker.ToLower() == ticker.ToLower())
                .Where(x => x.Timestamp >= from)
                .Where(x => x.Timestamp <= to)
                .ToListAsync(cancellationToken);
        }
    }
}
