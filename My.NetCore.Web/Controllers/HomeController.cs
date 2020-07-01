using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using My.NetCore.Helpers;
using My.NetCore.Options;
using My.NetCore.Web.Entitys;

namespace My.NetCore.Web.Controllers
{
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var test = My.NetCore.Helpers.ValidateCodeHelper.GetVerifyCode();

            var model = new UserModel()
            {
                ID = 1,
                UserName = "admin",
                Age = 12,
                BrithDate = System.DateTime.Now
            };

            var aa = model.MapTo<UserDOT>();
            aa.UserName = "admin11";

            return Json(aa);
        }

        [HttpPost]
        public IActionResult Test()
        {
            return Json("完成");
        }
    }
}