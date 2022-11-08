using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using NetTaskGetFront.Core.Infrastracture.PipelineBehaviours;
using System.Reflection;
using NetTaskGetFront.Core.Interfaces.Processors;
using NetTaskGetFront.Core.Services.Processors;
using NetTaskGetFront.Core.Interfaces.Services;
using NetTaskGetFront.Core.Services.Services;

namespace NetTaskGetFront.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            services.AddValidatorsFromAssembly(assembly);

            services.AddSingleton<IStockProcessor, StockProcessor>();
            services.AddSingleton<ITimeProvider, TimeProvider>();


            return services;
        }
    }
}
