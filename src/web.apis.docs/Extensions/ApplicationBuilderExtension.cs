using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// <see cref="IApplicationBuilder"/>的扩展方法
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// 启用API文档和文档UI
        /// </summary>
        /// <param name="this"></param>
        /// <param name="routePrefix">路由前缀</param>
        public static void UseApiDocs(this IApplicationBuilder @this, string docs1, string docs2)
        {
            var apiSchemePath = "/.docs/api-scheme.json";
            @this.UseSwagger(_ =>
            {
                _.RouteTemplate = ".docs/{documentName}-scheme.json";
            });

            @this.UseReDoc(_ =>
            {
                _.RoutePrefix = docs1;
                _.SpecUrl = apiSchemePath;
            });

            @this.UseSwaggerUI(_ =>
            {
                _.RoutePrefix = docs2;
                _.DefaultModelRendering(ModelRendering.Example);
                _.DefaultModelExpandDepth(3);
                _.DefaultModelsExpandDepth(3);
                _.DisplayRequestDuration();
                _.DocExpansion(DocExpansion.List);
                _.EnableDeepLinking();
                _.ShowExtensions();
                _.SwaggerEndpoint(apiSchemePath, "API Docs");
            });
        }
    }
}
