using System;
using System.IO;
using AsyncApi.SignalR;
using AsyncApi.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WhiteApp.Hubs;

namespace WhiteApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var options = new AsyncApiUiOptions("My WhiteApp", "1.0.1");
            
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "WhiteApp.xml");
            options.IncludeXmlComments(filePath);
            
            services.AddAsyncApiUi(options);
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAsyncApiUi(env);
            
            app.UseFileServer();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                app.UseAsyncApiSignalRHub<ChatHub, IChatHub>("/chat");
            });
        }
    }
}