using Microsoft.AspNetCore;
using Shifta.Pacientes.Api;

namespace GMegatlon.Ventas.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder(args);                

            return webHostBuilder.UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .Build();
        }
    }
}