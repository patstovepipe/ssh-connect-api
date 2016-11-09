using SSHConnectAPI.Utilities;
using SSHConnectAPI.Controllers;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace SSHConnectAPI.Filters
{
    public class ConnectionActionFilter : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as SSHConnectController;
            if (controller == null)
            {
                Logger.Log(this.GetType().Name, "Incorrect controller expected SSHConnectController");
                return;
            }

            controller.CheckConnection();
        }

    }
}