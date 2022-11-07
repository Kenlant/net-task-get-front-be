using Serilog;

namespace NetTaskGetFront.Web.Infrastracture.Installers
{
    public static class LoggerInstaller
    {
        public static IHostBuilder ConfigureAppLogging(this IHostBuilder builder)
        {
            builder.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });

            return builder;
        }
    }
}
