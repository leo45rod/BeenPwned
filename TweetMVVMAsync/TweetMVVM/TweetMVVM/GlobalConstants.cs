namespace TweetMVVM
{
    public class GlobalConstants
    {
        // REST configuration
        public static readonly string EndPointURL = "https://alert.eastonsd.org";
        public static readonly int RequestTimeout = 10 * 1000; // In milliseconds, time to return request

        public static readonly string NewsEndPointRequestURL            = "/api/News";
        public static readonly string SocialEndPointRequestURL          = "/api/Social";
        public static readonly string CalendarEndPointRequestURL        = "/api/Calendar";
        public static readonly string NavigationEndPointRequestURL      = "/api/NavigationItems";
        public static readonly string NotificationsEndPointRequestURL   = "/api/notifications";
        public static readonly string TagsEndPointRequestURL            = "/api/notifications/Tags";
        public static readonly string ConfigurationEndPointRequestURL = "/api/config";

        // Twitter configuration
        public static readonly string DefaultSocialImageSize = "small"; // thumb, small, medium, large
    }
}
