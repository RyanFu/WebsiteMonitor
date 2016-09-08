using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace websiteMonitor.Models.Twilio
{
    public class TwilioRequest
    {
        public string MessageSid { get; set; }
        public string AccountSid { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        //public int NumMedia { get; set; }
        //public string MediaContentType { get; set; }
        //public string MediaUrl { get; set; }
    }
}



//Notes, need to host on webServer
//https://www.twilio.com/docs/api/twiml/sms/message#nouns
//http://stackoverflow.com/questions/16772027/how-to-receive-sms-to-a-twilio-number //Best
//http://stackoverflow.com/questions/17757418/how-can-i-write-a-rest-api-to-receive-an-sms-via-twilio-number-using-asp-net-web