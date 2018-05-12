using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Watch.Run
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDocs();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseApiDocs(".docs");
            app.UseMvc();
        }
    }
}
