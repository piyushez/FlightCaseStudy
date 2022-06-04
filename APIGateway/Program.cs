using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //IWebHostBuilder builder = new WebHostBuilder();
            //builder.ConfigureServices(s =>
            //{
            //    s.AddSingleton(builder);
            //});
            //builder.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseStartup<Startup>()
            //    .ConfigureAppConfiguration(hostingcontext);
            //var host = builder.Build();
            //host.Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(config => config.AddJsonFile("configuration.json"));
                }).ConfigureLogging(logging => logging.AddConsole());
    }
}
