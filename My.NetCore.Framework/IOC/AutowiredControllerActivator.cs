using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace My.NetCore.Framework.IOC
{
    public class AutowiredControllerActivator : ServiceBasedControllerActivator, IControllerActivator {

        public AutowiredControllerActivator() : base() { }

        public new object Create(ControllerContext actionContext) {
            //default create controller function
            var controllerInstance = base.Create(actionContext);
            DependencyInjection.Resolve(actionContext.HttpContext.RequestServices, controllerInstance);
            return controllerInstance;
        }
    }
}
