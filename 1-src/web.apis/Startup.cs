using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Apis
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDocs();
            services.AddRouting();
            services.AddControllers();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseApiDocs(".docs1", ".docs2");
            app.UseRouting();
            app.UseEndpoints(_ => _.MapDefaultControllerRoute());
        }
    }
}
