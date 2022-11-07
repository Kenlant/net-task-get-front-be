using NetTaskGetFront.Core;
using NetTaskGetFront.Web.Infrastracture.Installers;
using NetTaskGetFront.Web.Infrastracture.Middlewares;

namespace NetTaskGetFront.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppMvc();
            services.AddAppOpenApi();
            services.AddCore();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseExceptionHandlingMiddleware();
            app.UseAppMvc();
            app.UseAppOpenApi();
        }
    }
}
