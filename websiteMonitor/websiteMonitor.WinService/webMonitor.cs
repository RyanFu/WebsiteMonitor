using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using websiteMonitor.WinService.Service;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;

namespace websiteMonitor.WinService
{
    public partial class webMonitor : ServiceBase
    {
        private Timer timer1 = null;

        public webMonitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 60000;  //Every 60 seconds
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_tick);
            timer1.Enabled = true;
            loggingService.WriteErrorLog("WebMonitor Service Started");
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            loggingService.WriteErrorLog("WebMonitor Service stopped.");
        }

        private void timer1_tick(object sender, ElapsedEventArgs e)
        {
            var service = new websiteService();
            using (var driver = new PhantomJSDriver())
            {
                driver.Navigate().GoToUrl("https://betterthandiamond.com/amora-gem-search.php");
                //driver.Navigate().GoToUrl("http://weddingmonitor.jeffwarddevelopment.com/");
                try
                {
                    var exists = driver.FindElement(By.ClassName("notificationlink"));
                    var exists2 = driver.FindElement(By.ClassName("notFound"));
                    {
                        var key = "(We are sold out! Please click here to be notified when we restock...)";
                        var key2 = "NO RESULTS";
                        if (exists.Text == key && exists2.Text == key2)
                        {
                            loggingService.WriteErrorLog(exists.Text + exists2.Text+"Ring out of stock as of " + DateTime.Now.ToString());


                        }
                        else
                        {
                            service.sendSMS();
                            loggingService.WriteErrorLog("Ring in stock!! Found at " + DateTime.Now.ToString());

                            Environment.Exit(0);
                        }
                        driver.Close();
                        driver.Quit();
                    }
                }
                catch (Exception error)
                {
                    loggingService.WriteErrorLog("Error caught! " + DateTime.Now.ToString() + "Message: " + error.ToString());

                    driver.Close();

                    driver.Quit();
                }



                driver.Close();
            }
        }
    }
}
