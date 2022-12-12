using System;
using System.IO;
using AsyncApi.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AsyncApi.UI
{
    public static class AsyncApiUIApplicationBuilderExtensions
    {
        public static IServiceCollection AddAsyncApiUi(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<AsyncApiBuilder>();

            return serviceCollection;
        }
        
        public static IApplicationBuilder UseAsyncApiUi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var asyncBuilder = app.ApplicationServices.GetService(typeof(AsyncApiBuilder)) as AsyncApiBuilder;
            if (asyncBuilder == null)
            {
                throw new NotSupportedException("Please call services.AddAsyncApiUi() on IServiceCollection");
            }
            
            app.Map("/asyncapi",
                subApp =>
                {
                    var type = typeof(AsyncApiUIApplicationBuilderExtensions);
                    var fileProvider = new EmbeddedFileProvider(type.Assembly);

                    var options = new DefaultFilesOptions
                    {
                        FileProvider = fileProvider
                    };
                    options.DefaultFileNames.Add("index.html");
                    subApp.UseDefaultFiles(options);
                    
                    
                    subApp.UseRouter(endpoints =>
                    {
                        endpoints.MapGet("/asyncapi.yml", async http =>
                        {
                            await http.Response.WriteAsync(asyncBuilder.Serialize());
                        });
                    });
                    
                    subApp.UseStaticFiles(new StaticFileOptions
                    {
                        FileProvider = fileProvider,
                        ServeUnknownFileTypes = true
                    });
                });
            
            return app;
        }

        
    }
}