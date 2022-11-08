using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NetTaskGetFront.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NetTaskGetFrontDbContext>
    {
        private const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";

        public NetTaskGetFrontDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../NetTaskGetFront.Web");
            
            var connectionString = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .Build()
                .GetConnectionString("NetTaskGetFront");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string is not defined", nameof(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<NetTaskGetFrontDbContext>()
                .UseSqlServer(connectionString);

            return new NetTaskGetFrontDbContext(optionsBuilder.Options);
        }
    }
}
