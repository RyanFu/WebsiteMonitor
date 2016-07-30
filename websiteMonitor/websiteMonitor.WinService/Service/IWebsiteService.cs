namespace websiteMonitor.WinService.Service
{
    public interface IWebsiteService
    {
        bool WatchWeddingData(string website);
        bool sendSMS();
        bool sendErrorSMS();
        bool sendStartSMS();
        bool sendNoElementPresent();
    }
}