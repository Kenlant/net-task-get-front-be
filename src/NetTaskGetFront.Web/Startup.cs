using NetTaskGetFront.Core;
using NetTaskGetFront.PolygonStockService;
using NetTaskGetFront.Web.Infrastracture.Installers;
using NetTaskGetFront.Web.Infrastracture.Middlewares;

namespace NetTaskGetFront.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppMvc();
            services.AddAppOpenApi();
            services.AddCore();
            services.AddPoligonStockService(_configuration);
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
