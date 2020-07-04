using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using My.NetCore.Framework.Helpers;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.Options;
using My.NetCore.FrameworkTest.Entitys;
using My.NetCore.FrameworkTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.FrameworkTest.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class UserController : Controller
    {
        ////[Autowired]
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var aaa = EnginContext.Current.Resolve<IConfiguration>();
            var bbb = EnginContext.Current.Resolve<IUserService>();

            var ccc = ConfigHelper.GetSetting<ConsulOption>("AppConfig:Consul");


            //var aa = RedisCacheHelper.Set("name", ccc);
            //var bb = RedisCacheHelper.Get<ConsulOption>("name");

            //Console.WriteLine("测试日志");
            //_logger.LogInformation("测试日志");
            //var bb = EnginContext.Current.Resolve<IOptions<AppSettingOption>>();
            //var aa = EnginContext.Current.Resolve<UserService>();

            _userService.DoSomeThink();
            //_userService.DoSomeThink();

            //var test = _userService.DeleteByIds(new List<object>() { 72, 74 }.ToArray());

            //var model = _userService.GetModel(73);

            //var aaaa = _userService.Delete(model);


            //var list1 = _userService.GetList(w => w.ID < 74).ToList();

            //var test = _userService.Delete(list1);

            var list = _userService.GetList(w => w.ID > 1);
            return Json(list);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            UserModel model = new UserModel() { Age = 123123, UserName = "admin", Email = "admin@123.com", BrithDate = DateTime.Now };
            var test1 = _userService.Insert(model);

            List<UserModel> list = new List<UserModel>();
            list.Add(new UserModel() { Age = 12, UserName = "list1", Email = "list1@123.com", BrithDate = DateTime.Now });
            list.Add(new UserModel() { Age = 15, UserName = "list2", Email = "list2@123.com", BrithDate = DateTime.Now });
            var test2 = _userService.Insert(list);

            return Json(new { });
        }

        [HttpGet]
        public IActionResult Update()
        {
            UserModel model = new UserModel() { ID = 1, Age = 100, UserName = "user1", Email = "user1@123.com", BrithDate = DateTime.Now };
            var test = _userService.Update(model);

            List<UserModel> list = new List<UserModel>();
            list.Add(new UserModel() { ID = 2, Age = 122, UserName = "user2", Email = "list1@123.com", BrithDate = DateTime.Now });
            list.Add(new UserModel() { ID = 3, Age = 135, UserName = "user3", Email = "list2@123.com", BrithDate = DateTime.Now });
            var test2 = _userService.Update(list);

            return Json(new { });
        }

        [HttpGet]
        public IActionResult Delete()
        {
            //UserModel model = new UserModel() { ID = 1, Age = 100, UserName = "user1", Email = "user1@123.com", BrithDate = DateTime.Now };
            //var test1 = _userService.Delete(model);

            List<UserModel> list = new List<UserModel>();
            list.Add(new UserModel() { ID = 5, Age = 122, UserName = "user2", Email = "list1@123.com", BrithDate = DateTime.Now });
            list.Add(new UserModel() { ID = 6, Age = 135, UserName = "user3", Email = "list2@123.com", BrithDate = DateTime.Now });
            var test2 = _userService.Delete(list);

            //var test3 = _userService.DeleteByID(2);

            //var test4 = _userService.DeleteByIds(new List<object>() { 3, 4 }.ToArray());

            return Json(new { });
        }

        [HttpGet]
        public IActionResult GetModel()
        {
            var test = _userService.GetModel(3);

            return Json(new { });
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var list= _userService.GetList(w => w.ID > 0);
            return Json(list);
        }
    }
}
