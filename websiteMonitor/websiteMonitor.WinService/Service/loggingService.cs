using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace websiteMonitor.WinService.Service
{
    public static class loggingService
    {


        public static void WriteErrorLog(string Message)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + " : " + Message.ToString());
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
               
            }

        }
    }
}
