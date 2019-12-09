using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace Dotnet.Watch.Run
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(UseStartup)
                .Build()
                .Run();
        }

        private static void UseStartup(IWebHostBuilder web)
        {
            web.CaptureStartupErrors(true)
               .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseIISIntegration()
               .UseStartup<Startup>();
        }
    }
}
