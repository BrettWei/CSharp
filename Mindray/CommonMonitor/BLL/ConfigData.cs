using System;
using System.Configuration;

namespace BLL
{
    public class ConfigData
    {
        //public static readonly string ConnStr = System.Configuration.ConfigurationManager.AppSettings["ConnStr"].ToString();
        public static readonly string LogPath = System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString();
        public static readonly string ConfigFile = System.Configuration.ConfigurationManager.AppSettings["ConfigFile"].ToString();

        public static readonly string MailServer = System.Configuration.ConfigurationManager.AppSettings["MailServer"].ToString();
        private static readonly string m_MailServerPort = System.Configuration.ConfigurationManager.AppSettings["MailServerPort"].ToString();
        public static readonly string MailSendAccount = System.Configuration.ConfigurationManager.AppSettings["MailSendAccount"].ToString();
        public static readonly string MailSendAccountPWD = System.Configuration.ConfigurationManager.AppSettings["MailSendAccountPWD"].ToString();

        public static int MailServerPort
        {
            get {

                try
                {
                    int re = Convert.ToInt32(m_MailServerPort);
                    return re;
                }
                catch
                {
                    return 25;
                }
            }
        }

        //public static readonly string MailURL = System.Configuration.ConfigurationManager.AppSettings["MailURL"].ToString();
    }
}
