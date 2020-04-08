using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Security
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public PermissionAuthorizationRequirement(string name = "", string controller = "", string action = "")
        {
            Name = name;
            Controller = controller;
            Action = action;
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
    }
}
