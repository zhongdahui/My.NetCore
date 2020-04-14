using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using My.NetCore.Helpers;
using My.NetCore.Options;
using My.NetCore.Web.Entitys;

namespace My.NetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
    }
}