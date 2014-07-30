using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class MonitorEntity
    {
        private string m_ConnStr = "";
        public string ConnStr
        {
            set { m_ConnStr = value; }
            get { return m_ConnStr; }
        }

        private string m_SQL = "";
        public string SQL
        {
            set { m_SQL = value; }
            get { return m_SQL; }
        }

        private string m_SQLType = "";
        public string SQLType    
        {
            set { m_SQLType = value; }
            get { return m_SQLType; }
        }

        private string m_MailTo = "";
        public string MailTo
        {
            set { m_MailTo = value; }
            get { return m_MailTo; }
        }

        private string m_MailSubject = "";
        public string MailSubject
        {
            set { m_MailSubject = value; }
            get { return m_MailSubject; }
        }

        private string m_ReturnID = "";
        public string ReturnID
        {
            set { m_ReturnID = value; }
            get { return m_ReturnID; }
        }
    }
}
