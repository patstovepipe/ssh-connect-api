using SSHConnectAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SSHConnectAPI.Controllers
{
    public class LoggerController : Controller
    {
        public ActionResult Logs()
        {
            var lines = string.Join("", Logger.Logs().Select(l => "<p style='margin:0'>" + l + "</p>"));
            return Content(lines);
        }
    }
}