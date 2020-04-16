using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using My.NetCore.Helpers;
using My.NetCore.IOC;
using My.NetCore.Model;
using My.NetCore.Options;
using My.NetCore.Web.Entitys;
using My.NetCore.Web.Services;
using System;
using System.Security.Claims;

namespace My.NetCore.Web.Controllers
{
    public class LoginModel 
    { 
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    [Route("[Controller]/[Action]")]
    [ApiController]
    public class UserController: Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (loginModel.UserName == "admin" && loginModel.Password == "123123")
            {
                var config = EnginContext.Current.Resolve<IOptions<AppSettingOption>>();
                string token = AuthenticationHelper.GetJwtToken(config.Value.JwtBearer, new TokenOption() { ID = 1, UserCode = "abc123", UserName = "admin", UserRole = "admin", UserWork = "aaa.bb", UserData = "{\"id\":1,\"name\":\"admin\"}", LoginTime = DateTime.Now });

                return Json(ResultVM.Success(token));
            }
            else
            {
                return Json(ResultVM.Fail("密码错误"));
            }
        }

        [Authorize]
        public IActionResult List()
        {
            string token = AuthenticationHelper.GetToken(HttpContext);
            var list = AuthenticationHelper.GetClaimValueByType(HttpContext, ClaimTypes.UserData);

            return Json("list");
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
