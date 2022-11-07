using Microsoft.AspNetCore.Mvc;

namespace NetTaskGetFront.Web.Infrastracture.Installers
{
    public static class MvcInstaller
    {
        public static IServiceCollection AddAppMvc(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        public static IApplicationBuilder UseAppMvc(this IApplicationBuilder builder)
        {
            builder.UseRouting();
            builder.UseEndpoints(options => options.MapControllers());

            return builder;
        }

    }
}
