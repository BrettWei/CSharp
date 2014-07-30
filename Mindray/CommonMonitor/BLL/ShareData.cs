using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class ShareData
    {
        private static string m_MailMsg = "";
        public static string MailMsg
        {
            get { return m_MailMsg; }
        }

        public static void AddMailMsg(string content)
        {
            m_MailMsg = m_MailMsg + DateTime.Now.ToString() + ": " + content + "<br/>";
        }

        public static void CleanMailMsg()
        {
            m_MailMsg = "";
        }
    }
}
