using Microsoft.AspNetCore.Mvc;

namespace My.NetCore.FrameworkTest.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(new { id = 1, name = "abc" });
        }
    }
}
