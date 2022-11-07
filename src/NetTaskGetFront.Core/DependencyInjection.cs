using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using NetTaskGetFront.Core.Infrastracture.PipelineBehaviours;
using System.Reflection;

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

            return services;
        }
    }
}
