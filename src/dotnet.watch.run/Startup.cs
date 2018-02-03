using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Web.Apis.Extensions;

namespace Dotnet.Watch.Run
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDoc("api-docs");
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseApiDoc();
            app.UseMvc();
        }
    }
}
