using Microsoft.AspNetCore.Mvc;
using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.FrameworkTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.FrameworkTest.Controllers
{
    public class UserController : Controller
    {
        [Autowired]
        private  IUserService _userService { get; set; }

        [HttpGet]
        public IActionResult Index()
        {

            _userService.DoSomeThink();
            var list = _userService.Query(w => w.ID > 1);
            return Json(list);
        }
    }
}
