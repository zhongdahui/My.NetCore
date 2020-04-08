using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Web.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/values")]
    [ApiController]
    public class ValuesV2Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 from Version 2", "value2 from Version 2" };
        }
    }
}
