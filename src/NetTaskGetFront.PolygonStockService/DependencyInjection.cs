using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetTaskGetFront.Core.Interfaces.Services;
using NetTaskGetFront.PolygonStockService.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System.Net.Http.Headers;

namespace NetTaskGetFront.PolygonStockService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPoligonStockService(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(PoligonServiceOptions.Position).Get<PoligonServiceOptions>();
            services.AddSingleton<IStockService, PoligonStockService>();
            services.AddRefitClient<IPoligonHttpClient>(new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        })
                })
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(options.BaseUrl);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.ApiKey);
                });

            return services;
        }
    }
}
