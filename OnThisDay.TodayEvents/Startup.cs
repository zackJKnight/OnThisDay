using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OnThisDay.TodayEventData;
using System;
using System.Collections.Generic;
using System.Text;
using OnThisDay.TodayEvents.Services;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace OnThisDay.TodayEvents
{
    public class Startup
    {
        public static string NytApiKey {get; private set;}

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITodayEventRepository, TodayEventRepository>();
            services.AddGrpc();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var builder = new ConfigurationBuilder();
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
                NytApiKey = Configuration["API_KEY_NYT"];
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<TodayEventService>();
            });
        }
    }
}
