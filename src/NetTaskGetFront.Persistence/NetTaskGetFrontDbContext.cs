using Microsoft.EntityFrameworkCore;
using NetTaskGetFront.Domain.Entities;
using System.Reflection;

namespace NetTaskGetFront.Persistence
{
    public class NetTaskGetFrontDbContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }

        public NetTaskGetFrontDbContext(DbContextOptions<NetTaskGetFrontDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
