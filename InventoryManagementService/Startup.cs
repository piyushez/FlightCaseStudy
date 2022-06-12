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
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


            //    x.AddConsumer<InventoryConsumer>();

            //    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            //    {
            //        cfg.Host(new Uri("rabbitmq://localhost"), h =>
            //        {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });
            //        cfg.ReceiveEndpoint("todoQueue1", ep =>
            //        {

            //            ep.UseRawJsonSerializer();

            //            ep.PrefetchCount = 16;
            //            ep.UseMessageRetry(x => x.Interval(2, 100));

            //            ep.ConfigureConsumer<InventoryConsumer>(provider);
            //        });
            //    }));
            //});

            //services.AddMassTransitHostedService();

            var authenticationProviderKey = "TestKey";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = authenticationProviderKey;

            }).AddJwtBearer(authenticationProviderKey, o =>
            {

                var key = Encoding.UTF8.GetBytes("This is my First Authentication JWT");
                o.SaveToken = true;
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:58477",
                    ValidAudience = "http://localhost:58477",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

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
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:41888", "http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
