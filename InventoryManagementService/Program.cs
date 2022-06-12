using GreenPipes;
using InventoryService.Repository;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    cfg.Host(new Uri("rabbitmq://localhost/todoQueue1"), h =>
            //    {
            //        h.Username("guest");
            //        h.Password("guest");
            //    });
            //    cfg.ReceiveEndpoint("todoQueue1", ep =>
            //    {
            //        ep.PrefetchCount = 16;
            //        ep.UseMessageRetry(r => r.Interval(2, 100));
            //        ep.Consumer<InventoryConsumer>();
            //    });

            //});

            //bus.StartAsync();




        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
