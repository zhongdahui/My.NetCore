using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using My.NetCore.AutoMapper;
using My.NetCore.Helpers;
using My.NetCore.IOC;
using My.NetCore.Options;
using My.NetCore.Web.Entitys;
using My.NetCore.Web.Services;

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