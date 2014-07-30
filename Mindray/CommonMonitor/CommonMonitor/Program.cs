using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL.MainEntry me = new BLL.MainEntry();
            me.Start();
        }
    }
}
