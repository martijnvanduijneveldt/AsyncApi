using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AsyncApi.UI
{
    public static class AsyncApiUIApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAsyncApiUi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
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