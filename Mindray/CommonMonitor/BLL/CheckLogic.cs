using System;
using System.Data;
using System.Collections.Generic;
using System.Xml;

namespace BLL
{
    class CheckLogic
    {
        //private bool m_HaveErrorData = false;
        private List<MonitorEntity> monitors;

        public void IsHaveErrorData()
        {
            Logger.AddLogMsg("Begin InitCheckItems!");
            InitCheckItems();
            Logger.AddLogMsg("End InitCheckItems!");
            Logger.AddLogMsg("Begin CheckErrorData!");
            CheckErrorData();
            Logger.AddLogMsg("End CheckErrorData!");
            //return m_HaveErrorData;
        }

        private void InitCheckItems()
        {
            monitors = new List<MonitorEntity>();
            string XMLFile = ConfigData.ConfigFile;
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFile);

            XmlNodeList Root = doc.SelectNodes("Root");
            if (Root != null && Root.Count > 0)
            {
                XmlNodeList nodes = Root[0].SelectNodes("MonitorEntity");

                foreach (XmlNode node in nodes)
                {
                    MonitorEntity me = new MonitorEntity();
                    XmlNodeList entity = node.ChildNodes;

                    foreach (XmlNode attr in entity)
                    {
                        if (attr.Name == "SQL")
                        {
                            me.SQL = attr.InnerText;
                        }
                        else if (attr.Name == "SQLType")
                        {
                            me.SQLType = attr.InnerText;
                        }
                        else if (attr.Name == "MailTo")
                        {
                            me.MailTo = attr.InnerText;
                        }
                        else if (attr.Name == "MailSubject")
                        {
                            me.MailSubject = attr.InnerText;
                        }
                        else if (attr.Name == "ReturnID")
                        {
                            me.ReturnID = attr.InnerText;
                        }
                        else if (attr.Name == "ConnStr")
                        {
                            me.ConnStr = attr.InnerText;
                        }
                    }

                    monitors.Add(me);
                }
            }

            Logger.AddLogMsg("Monitor Counts:" + monitors.Count.ToString());
        }

        private void CheckErrorData()
        {
            foreach (MonitorEntity me in monitors)
            {
                Logger.AddLogMsg("Begin Check for " + me.MailSubject);
                string sql = me.SQL;
                string returnID = me.ReturnID;
                string returnIDs = "";
                try
                {
                    DBHepler db = new DBHepler(me.ConnStr);
                    DataSet ds = db.GetSQLDS(sql);
                    if (ds == null || ds.Tables.Count == 0)
                    {
                        throw new Exception("Get data from DB meet error in CheckErrorData! For " + me.MailSubject);
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Logger.AddLogMsg("Get " + ds.Tables[0].Rows.Count.ToString() + " rows data!");
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                returnIDs += ds.Tables[0].Rows[i][returnID].ToString() + "<br/>";
                            }
                            throw new Exception(me.MailSubject + " 有" + ds.Tables[0].Rows.Count.ToString() + "个错误数据! IDs 如下 <br/>" + returnIDs);
                        }
                    }
                }
                catch (Exception ee)
                {
                    Logger.AddLogMsg(ee.Message);
                    ShareData.AddMailMsg(ee.Message);

                    HandleMail hm = new HandleMail();
                    hm.SendMail(me.MailTo, me.MailSubject, ShareData.MailMsg);
                }
                finally
                {
                    Logger.AddLogMsg("End Check for " + me.MailSubject); 
                }
            }
        }

    }
}
