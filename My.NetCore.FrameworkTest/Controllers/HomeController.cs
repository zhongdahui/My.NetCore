using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.FrameworkTest.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.FrameworkTest.Controllers
{
    public class HomeController: ControllerBase
    {

        [Autowired]
        private IOptions<SnowflakeConfig> options { get; set; }

        public IActionResult Index()
        {
            //int test = options.Value.DataCenter;

            return new JsonResult(new { id = 1, name = "abc" });
        }
    }
}
