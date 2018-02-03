using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Watch.Run.Controllers
{
    [Route("/")]
    public class ValuesController : Controller
    {
        [HttpGet("")]
        public object Get()
        {
            var currentUrl = base.Request.GetDisplayUrl();
            return new
            {
                _self = currentUrl,
                value = "blackheart"
            };
        }
    }
}
