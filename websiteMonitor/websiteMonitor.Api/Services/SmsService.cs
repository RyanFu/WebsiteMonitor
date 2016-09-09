using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;

namespace websiteMonitor.Api.Services
{
    public class SmsService : ISmsService
    {
        public bool WatchWeddingData(string website)
        {

            return true;
        }


        public bool SendSms()
        {


            // set our AccountSid and AuthToken
            string accountSid = "AC61b76d7cf5033d39d3fdf1a6816e3e61";
            string authToken = "1f4545334cf64e12d68a224de622178c";

            string ToPhone = "+19492593445";
            string FromPhone = "+16176740897";


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

        public bool SendErrorSms()
        {


            // set our AccountSid and AuthToken
            string accountSid = "AC61b76d7cf5033d39d3fdf1a6816e3e61";
            string authToken = "1f4545334cf64e12d68a224de622178c";

            string ToPhone = "+19492593445";
            string FromPhone = "+16176740897";


            // instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(accountSid, authToken);
            try
            {
                // var call = client.InitiateOutboundCall(options);
                client.SendMessage(FromPhone, ToPhone, "Brooklyn! There is an error, ask Jeff to fix it! :)");

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool SendStartSms()
        {


            // set our AccountSid and AuthToken
            string accountSid = "AC61b76d7cf5033d39d3fdf1a6816e3e61";
            string authToken = "1f4545334cf64e12d68a224de622178c";

            string ToPhone = "+19492593445";
            string FromPhone = "+16176740897";


            // instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(accountSid, authToken);
            try
            {
                // var call = client.InitiateOutboundCall(options);
                client.SendMessage(FromPhone, ToPhone, "Brooklyn! Let the monitoring begin! :)");

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool SendNoElementPresent()
        {


            // set our AccountSid and AuthToken
            string accountSid = "AC61b76d7cf5033d39d3fdf1a6816e3e61";
            string authToken = "1f4545334cf64e12d68a224de622178c";

            string ToPhone = "+19492593445";
            string FromPhone = "+16176740897";


            // instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(accountSid, authToken);
            try
            {
                // var call = client.InitiateOutboundCall(options);
                client.SendMessage(FromPhone, ToPhone, "Brooklyn! Bump in the road! There MAY be an amora gem for sale.  If you get several of these in a row, its for sale!");

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}