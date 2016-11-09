using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SSHConnectAPI.Utilities
{
    public class Logger
    {
        public static string logFile = AppDomain.CurrentDomain.BaseDirectory + "log.txt";

        public static void Log(string tag, string message)
        {
            string logMessage = string.Format("{0}: {1}: {2}", DateTime.Now, tag, message);
            File.AppendAllText(logFile, logMessage + Environment.NewLine);
        }

        public static string[] Logs()
        {
            return File.ReadAllLines(logFile);
        }
    }
}