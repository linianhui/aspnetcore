using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace Web.Apis
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDocs();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseApiDocs(".docs",".docs2");
            app.UseMvc();
        }
    }
}
