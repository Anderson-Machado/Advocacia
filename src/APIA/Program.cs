using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace APIA
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            ILoggerFactory loggerFactory = new LoggerFactory()
               .AddConsole()
   .AddDebug();
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation(
              "This is a test of the emergency broadcast system.");

            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddJsonFile("appsettings.Prodution.json", optional: true)
            .Build();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            var connectionString = config.GetConnectionString("BaseIdentity");
            logger.LogInformation("STRING CONEXÃO--->>>:"+connectionString,3);
            // host.Run();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
