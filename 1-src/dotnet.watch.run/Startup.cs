using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Watch.Run
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDocs();
            services.AddRouting();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseApiDocs(".docs1", ".docs2");
            app.UseRouting();
            app.UseEndpoints(_ => _.MapDefaultControllerRoute());
        }
    }
}
