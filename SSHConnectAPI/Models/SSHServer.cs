using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace SSHConnectAPI.Models
{
    public class SSHServer
    {
        public string host { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public SSHServer()
        {
            var appSettingsSshHost = ConfigurationManager.AppSettings["sshHost"];
            var appSettingsSshPort = ConfigurationManager.AppSettings["sshPort"];
            var appSettingsSshUsername = ConfigurationManager.AppSettings["sshUsername"];
            var appSettingsSshPassword = ConfigurationManager.AppSettings["sshPassword"];

            if (string.IsNullOrEmpty(appSettingsSshHost) || string.IsNullOrEmpty(appSettingsSshPort) || string.IsNullOrEmpty(appSettingsSshUsername) || string.IsNullOrEmpty(appSettingsSshPassword))
            {
                var contents = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "sshdetails.txt");
                appSettingsSshHost = contents[0];
                appSettingsSshPort = contents[1];
                appSettingsSshUsername = contents[2];
                appSettingsSshPassword = contents[3];
            }

            this.host = appSettingsSshHost;
            this.port = Convert.ToInt32(appSettingsSshPort);
            this.username = appSettingsSshUsername;
            this.password = appSettingsSshPassword;
        }
    }
}