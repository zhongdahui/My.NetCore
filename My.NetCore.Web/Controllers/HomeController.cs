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
            var test = Convert.ToBase64String(QRCodeHelper.GetQRCode("abcabcabcagd123").ToArray());
            return File(QRCodeHelper.GetQRCode("abcabcabcagd123").ToArray(), "image/png");
        }
    }
}