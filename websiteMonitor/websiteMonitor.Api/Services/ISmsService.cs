namespace websiteMonitor.Api.Services
{
    public interface ISmsService
    {
        bool WatchWeddingData(string website);
        bool SendSms();
        bool SendErrorSms();
        bool SendStartSms();
        bool SendNoElementPresent();
    }
}