using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OnThisDay.TodayEventData;
using System;
using System.Collections.Generic;
using System.Text;
using OnThisDay.TodayEvents.Services;

namespace OnThisDay.TodayEvents
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITodayEventRepository, TodayEventRepository>();
            services.AddGrpc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
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
