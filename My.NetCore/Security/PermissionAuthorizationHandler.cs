using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace My.NetCore.Security
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            if (context.User != null)
            {
                if (context.User.IsInRole("admin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var data = context.User.FindFirst(a => a.Type == ClaimTypes.UserData);

                    if (data != null)
                    {
                        List<string> list = data.Value.ToLower().Split(',').ToList();

                        if (list.Contains(string.Format("{0}.{1}", requirement.Controller.ToLower(), requirement.Action.ToLower())))
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
