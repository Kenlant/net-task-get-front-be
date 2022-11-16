using NetTaskGetFront.Domain.Entities;

namespace NetTaskGetFront.Core.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateBatchAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
