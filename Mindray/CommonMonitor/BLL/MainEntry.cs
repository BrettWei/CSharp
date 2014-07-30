using System;

namespace BLL
{
    public class MainEntry
    {
        public void Start()
        {
            //HandleMail hm = new HandleMail();
            //hm.SendMail("weijie@eeka.cn", "Test", "Test");
            //Logger.WriteLog();
            //return;
            Logger.CleanLogMsg();
            CheckLogic cl = new CheckLogic();
            cl.IsHaveErrorData();
            //if (cl.IsHaveErrorData())
            //{
            //    HandleMail hm = new HandleMail();
            //    hm.SendMail(ShareData.ErrorMsg);
            //    //Logger.WriteLog(ShareData.ErrorMsg);
            //}
            Logger.WriteLog();
        }

    }
}
