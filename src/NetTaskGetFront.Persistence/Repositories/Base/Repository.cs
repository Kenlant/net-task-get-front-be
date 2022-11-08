using NetTaskGetFront.Core.Interfaces.Repositories.Base;

namespace NetTaskGetFront.Persistence.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly NetTaskGetFrontDbContext _dbContext;

        public Repository(NetTaskGetFrontDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateBatchAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
