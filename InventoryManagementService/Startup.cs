using GreenPipes;
using InventoryService.DBContext;
using InventoryService.Repository;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddDbContextPool<InventoryDbContext>
            (options => options.UseSqlServer(Configuration.GetConnectionString("FlightDatabase")));


            //services.AddMassTransit(x =>
            //{
            //    x.AddConsumer<InventoryRepository>();
            //    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            //    {
            //        cfg.Host(new Uri("rabbitmq://localhost"), h =>
            //        {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });
            //        cfg.ReceiveEndpoint("todoQueue1", ep =>
            //        {
            //            ep.PrefetchCount = 16;
            //            ep.UseMessageRetry(x => x.Interval(2, 100));
            //            ep.ConfigureConsumer<InventoryRepository>(provider);
            //        });
            //    }));
            //});

            //services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
