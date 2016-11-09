using Renci.SshNet;
using SSHConnectAPI.Filters;
using SSHConnectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSHConnectAPI.Controllers
{
    [SSHConnectAuthorizeFilter]
    [ConnectionActionFilter]
    public class SSHConnectController : Controller
    {
        public SSHConnection sshConnection { get; set; }

        public void CheckConnection()
        {
            if (sshConnection == null)
                sshConnection = new SSHConnection();

            if (!sshConnection.IsConnected())
                sshConnection.Connect();
        }

        public ActionResult Connect()
        {
            return Json(sshConnection.IsConnected(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsConnected()
        {
            return Json(sshConnection.IsConnected(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Restart()
        {
            return Json(sshConnection.RestartServer(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Shutdown()
        {
            return Json(sshConnection.ShutdownServer(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult KillProcess(string id)
        {
            return Json(sshConnection.KillProcess(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult KillProcessList()
        {
            return Json(SSHConnection.killProcessList, JsonRequestBehavior.AllowGet);
        }
    }
}