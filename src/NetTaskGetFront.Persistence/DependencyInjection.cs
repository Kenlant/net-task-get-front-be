using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetTaskGetFront.Core.Interfaces.Repositories;
using NetTaskGetFront.Persistence.Repositories;

namespace NetTaskGetFront.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("NetTaskGetFront");

            services.AddDbContext<NetTaskGetFrontDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IStockRepository, StockRepository>();   

            return services;
        }
    }
}
