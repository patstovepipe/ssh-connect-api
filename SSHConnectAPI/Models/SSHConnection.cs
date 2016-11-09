using Renci.SshNet;
using Renci.SshNet.Common;
using SSHConnectAPI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SSHConnectAPI.Models
{
    public class SSHConnection
    {
        public static string[] killProcessList;// = new List<string>() { "lxterminal" };

        private SSHServer server;
        private SshClient client;

        public SSHConnection()
        {
            killProcessList = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "killProcessList.txt");

            server = new SSHServer();

            client = new SshClient(server.host, server.port, server.username, server.password);
        }

        public void Connect()
        {
            try
            {
                client.Connect();
            }
            catch (Exception ex)
            {
                Logger.Log(this.GetType().Name, ex.Message);
            }
        }

        public bool IsConnected()
        {
            return client.IsConnected;
        }

        public bool RestartServer()
        {
            try
            {
                client.CreateCommand(string.Format("echo {0} | sudo -S shutdown -r now", server.password)).Execute();
            }
            catch (Exception ex)
            {
                // we don't want to catch ssh connection exception because that means we were successfull with previous command
                if (!(ex is SshConnectionException))
                    Logger.Log(this.GetType().Name, ex.Message);
            }

            return client.IsConnected;
        }

        public bool ShutdownServer()
        {
            try
            {
                client.CreateCommand(string.Format("echo {0} | sudo -S shutdown now", server.password)).Execute();
            }
            catch (Exception ex)
            {
                // we don't want to catch ssh connection exception because that means we were successfull with previous command
                if (!(ex is SshConnectionException))
                    Logger.Log(this.GetType().Name, ex.Message);
            }

            return client.IsConnected;
        }

        public bool KillProcess(string processName)
        {
            var processKilled = false;
            if (client.IsConnected && killProcessList.Contains(processName))
            {
                client.CreateCommand("pkill " + processName).Execute();
                processKilled = client.CreateCommand(string.Format("ps aux | awk '/{0}/ && !/awk/ {{print $2}}'", processName)).Execute() == "" ? true : false;
            }
            else
                Logger.Log(this.GetType().Name, string.Format("The process name {0} is not on the list of approved processes that can be killed.", processName));

            return processKilled;
        }
    }
}