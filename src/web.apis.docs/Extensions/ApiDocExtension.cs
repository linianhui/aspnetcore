using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Web.Apis.Docs;

// ReSharper disable CheckNamespace

namespace Web.Apis.Extensions
{
    public static class ApiDocExtension
    {
        public static void AddApiDoc(this IServiceCollection @this, string path)
        {
            ApiDocOptions.Path = path;
            @this.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc("v1", new Info { Title = "API Docs" });
            });
        }


        public static void UseApiDoc(this IApplicationBuilder @this)
        {
            @this.UseSwagger(_ =>
            {
                _.RouteTemplate = ApiDocOptions.Path + "/{documentName}/api-scheme.json";
            });

            @this.UseSwaggerUI(_ =>
            {
                _.RoutePrefix = ApiDocOptions.Path;
                _.SwaggerEndpoint($"/{ApiDocOptions.Path}/v1/api-scheme.json", "API Docs");
            });
        }
    }
}
