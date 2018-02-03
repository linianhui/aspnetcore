using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Web.Apis.Extensions;
namespace Web.Apis
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDoc("api-docs");
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseApiDoc();
            app.UseMvc();
        }
    }
}
