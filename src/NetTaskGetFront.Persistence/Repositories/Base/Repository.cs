using NetTaskGetFront.Core.Interfaces.Repositories.Base;

namespace NetTaskGetFront.Persistence.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly NetTaskGetFrontDbContext Context;

        public Repository(NetTaskGetFrontDbContext dbContext)
        {
            Context = dbContext;
        }

        public async Task CreateBatchAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().AddRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}
