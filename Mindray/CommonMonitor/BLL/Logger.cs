using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BLL
{
    class Logger
    {

        private static string m_LogMsg = "";
        public static string LogMsg
        {
            get { return m_LogMsg; }
        }

        private static string LogPath = ConfigData.LogPath;

        public static void WriteLog()
        {
            string LogName = "CommonMonitor_Log_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                File.AppendAllText(LogPath + @"\" + LogName, m_LogMsg);
            }
            catch (Exception ee)
            { 
            }
        }

        public static void AddLogMsg(string content)
        {
            m_LogMsg = m_LogMsg + DateTime.Now.ToString() + ": " + content + Environment.NewLine;
        }

        public static void CleanLogMsg()
        {
            m_LogMsg = "";
        }

    }
}
