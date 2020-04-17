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
    public class HomeController : Controller
    {
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

        public IActionResult Test()
        {
            var list = System.IO.File.ReadAllLines("C:\\Users\\zhongdahui\\Desktop\\aaa.txt");

            if (list != null && list.Length > 0)
            {
                foreach (var item in list)
                {
                    var test = RedisCacheHelper.Del($"product_sku_stock_{item}_0");
                }
            }

            return Json("完成");
        }
    }
}