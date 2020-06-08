using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Options
{
    public class AuthenticationOption
    {
        public string AuthenticationScheme { get; set; } = "Cookies";
        public string AccessDeniedPath { get; set; } = "/User/AccessDenied";
        public string CookiePrefix { get; set; } = "";
        public string LoginPath { get; set; } = "/User/Login";
        public string LogoutPath { get; set; } = "/User/Logout";
        public string ReturnUrlParameter { get; set; } = "";
    }
}
