using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;

namespace websiteMonitor.Api.ScheduledTasks
{
    public class WebsiteCheckJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //'Job' Code here
        }
    }
}