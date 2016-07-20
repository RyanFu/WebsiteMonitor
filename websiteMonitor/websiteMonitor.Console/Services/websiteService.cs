using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace websiteMonitor.Console.Services
{
    public class websiteService
    {
        public bool WatchWeddingData(string website)
        {

            return true;
        }


        public bool sendSMS()
        {
            // set our AccountSid and AuthToken
            string accountSid = ConfigurationManager.AppSettings["Twilio_SID"];
            string authToken = ConfigurationManager.AppSettings["Twilio_Auth"];

            string ToPhone = ConfigurationManager.AppSettings["Brooklyn_Phone"];
            string FromPhone = ConfigurationManager.AppSettings["Twilio_Phone"];

       
            // instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(accountSid, authToken);
            try
            {
               // var call = client.InitiateOutboundCall(options);
                client.SendMessage(FromPhone, ToPhone, "Brooklyn! An Amora Gem is in stock! Go check it out :)");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
