using SSHConnectAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SSHConnectAPI.Filters
{
    public class LoggerExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;

            Logger.Log(this.GetType().Name, ex.Message);
            
        }
    }
}