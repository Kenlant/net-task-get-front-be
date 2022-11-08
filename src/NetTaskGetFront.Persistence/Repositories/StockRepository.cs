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
    }
}
