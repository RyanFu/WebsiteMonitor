﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using websiteMonitor.WinService.Service;


namespace websiteMonitor.WinService
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WebMonitor()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
