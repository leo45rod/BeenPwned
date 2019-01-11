namespace TweetMVVM
{
    public class GlobalConstants
    {
        // REST configuration
        public static readonly string EndPointURL = "https://haveibeenpwned.com/api/v2";
        public static readonly int RequestTimeout = 10 * 1000; // In milliseconds, time to return request


        public static readonly string AccountEndPointRequestURL          = "/breachedaccount/{account}";


    }
}
