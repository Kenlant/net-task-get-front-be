using Microsoft.EntityFrameworkCore;
using NetTaskGetFront.Persistence;

namespace NetTaskGetFront.Web.Infrastracture.Installers
{
    public static class PersistenceInstaller
    {
        public static IApplicationBuilder UsePersistence(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<NetTaskGetFrontDbContext>();
            context.Database.Migrate();

            return builder;
        }
    }
}
