using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Web.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/values")]
    [ApiController]
    public class ValuesV1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "Value1 from Version 1", "value2 from Version 1" };
        }
    }
}
