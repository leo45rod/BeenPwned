using System;
using System.Collections.Generic;
using System.Text;

namespace TweetMVVM.Helpers
{
    public static class TimeHelper
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan < TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0}s", timeSpan.Seconds);
            }
            else if (timeSpan < TimeSpan.FromMinutes(60))
            {
                result = String.Format("{0}m", timeSpan.Minutes);
            }
            else if (timeSpan < TimeSpan.FromHours(24))
            {
                result = String.Format("{0}h", timeSpan.Hours);
            }
            else 
            {
                result = dateTime.ToString("M");
            }

            return result;
        }
    }
}
