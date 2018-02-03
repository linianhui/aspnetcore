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
                value = "blackheart",
                api_docs = currentUrl + "api-docs"
            };
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
