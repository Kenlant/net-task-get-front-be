using NetTaskGetFront.Web;
using NetTaskGetFront.Web.Infrastracture.Installers;

Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(x => x.UseStartup<Startup>())
    .ConfigureAppLogging()
    .Build()
    .Run();
