using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Quartz;
using websiteMonitor.Api.Services;

namespace websiteMonitor.Api.ScheduledTasks
{
    public class WebsiteCheckJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            ISmsService service = new SmsService();
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
                            service.SendErrorSms();
                            LoggingService.WriteErrorLog(exists.Text + exists2.Text + " Ring out of stock as of " +
                                                         DateTime.Now.ToString());


                        }
                        else
                        {
                            service.SendSms();
                            LoggingService.WriteErrorLog("Ring in stock!! Found at " + DateTime.Now.ToString());

                            Environment.Exit(0);
                        }
                        driver.Close();
                        driver.Quit();
                    }
                }
                catch (OpenQA.Selenium.NoSuchElementException elementException)
                {
                    LoggingService.WriteErrorLog("No Element present! " + DateTime.Now.ToString() + " Message: " +
                                                 elementException.ToString());
                    service.SendNoElementPresent();

                }
                catch (JobExecutionException quartzException)
                {
                    LoggingService.WriteErrorLog("Quartz logging error!! " + DateTime.Now.ToString() + " Message: " +
                                                quartzException.ToString());
                    service.SendNoElementPresent();
                }
                catch (Exception error)
                {
                    LoggingService.WriteErrorLog("Error caught! " + DateTime.Now.ToString() + " Message: " + error.ToString());
                    service.SendErrorSms();
                    driver.Close();

                    driver.Quit();
                }




                driver.Close();
            }
        }
    }
}