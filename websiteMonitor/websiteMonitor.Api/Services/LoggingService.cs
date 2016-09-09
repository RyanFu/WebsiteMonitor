using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace websiteMonitor.Api.Services
{
    public static class LoggingService
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
