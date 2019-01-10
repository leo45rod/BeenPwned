using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


namespace TweetMVVM.Helpers
{
    public static class TweetParser
    {
        public static string Link(this string s, string url)
        {
            return string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", url, s);
        }
        public static string ParseURL(this string s)
        {
            return Regex.Replace(s, @"(http(s)?://)?([\w-]+\.)+[\w-]+(/\S\w[\w- ;,./?%&=]\S*)?", new MatchEvaluator(TweetParser.URL));
        }
        public static string ParseUsername(this string s)
        {
            return Regex.Replace(s, "(@)((?:[A-Za-z0-9-_]*))", new MatchEvaluator(TweetParser.Username));
        }
        public static string ParseHashtag(this string s)
        {
            return Regex.Replace(s, "(#)((?:[A-Za-z0-9-_]*))", new MatchEvaluator(TweetParser.Hashtag));
        }
        private static string Hashtag(Match m)
        {
            string x = m.ToString();
            string tag = x.Replace("#", "%23");
            return x.Link("https://twitter.com/search?f=tweets&q=" + tag);
        }
        private static string Username(Match m)
        {
            string x = m.ToString();
            string username = x.Replace("@", "");
            return x.Link("http://twitter.com/" + username);
        }
        private static string URL(Match m)
        {
            string x = m.ToString();
            return x.Link(x);
        }
    }
}
