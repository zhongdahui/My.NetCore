using Microsoft.AspNetCore.Mvc;
using My.NetCore.Web.Entitys;
using My.NetCore.Web.Services;
using System;

namespace My.NetCore.Web.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class UserController: Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult List()
        {
            var list = _userService.Query(a => a.ID > 0);

            //if (list != null)
            //{
            //    foreach (var item in list)
            //    {
            //        if (item is UserModel)
            //        {
            //            Console.WriteLine(string.Format("{0}--{1}--{2}--{3}", item.ID, item.UserName, item.Age, item.BrithDate));
            //        }
            //    }
            //}

            return Json(list);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _userService.GetUserByID(1, "admin");
            return Json(list);
        }

        [HttpGet]
        public IActionResult Index1()
        {
            var list = _userService.InsertUser(1, "admin", new UserModel() { ID = 1, UserName = "admin", Age = 12, BrithDate = DateTime.Now}); 
            return Json(list);
        }
    }
}
