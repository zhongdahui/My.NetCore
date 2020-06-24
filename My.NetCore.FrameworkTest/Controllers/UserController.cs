using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using My.NetCore.Framework.AOP;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.Framework.Options;
using My.NetCore.FrameworkTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.FrameworkTest.Controllers
{
    public class UserController : Controller
    {
        ////[Autowired]
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var bb = EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

            //var aa = EnginContext.Current.Resolve<UserService>();

            _userService.DoSomeThink();
            //_userService.DoSomeThink();

            var list =  _userService.GetList(w => w.ID > 1);
            return Json(list);
        }
    }
}
