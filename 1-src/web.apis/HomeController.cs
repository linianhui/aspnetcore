using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Web.OAuth2.Resources.Apis
{
    /// <summary>
    /// 首页
    /// </summary>
    [Route("")]
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            string authority = new Uri(this.Request.GetDisplayUrl())
                .GetLeftPart(UriPartial.Authority);

            return Json(new Dictionary<string, object>
            {
                ["api_scheme"] = authority + "/.docs/api-scheme.json",
                ["docs1"] = authority + "/.docs1",
                ["docs2"] = authority + "/.docs2",
            });
        }
    }
}
