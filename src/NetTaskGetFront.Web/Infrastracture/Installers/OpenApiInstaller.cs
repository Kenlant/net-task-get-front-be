using NSwag;

namespace NetTaskGetFront.Web.Infrastracture.Installers
{
    public static class OpenApiInstaller
    {
        public static IServiceCollection AddAppOpenApi(this IServiceCollection services)
        {
            services.AddSwaggerDocument(options =>
            {
                options.PostProcess = document =>
                {
                    document.Info.Title = ".Net Task (get front) API";
                    document.Info.Description = "API for storing and retrieving stock data";
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "Vladyslav Svietlov",
                        Email = "svietlov.vladislav@gmail.com"
                    };
                };
            });

            return services;
        }

        public static IApplicationBuilder UseAppOpenApi(this IApplicationBuilder builder)
        {
            builder.UseOpenApi();
            builder.UseSwaggerUi3(options => options.Path = "/api");

            return builder;
        }
    }
}
