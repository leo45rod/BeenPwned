using TweetMVVM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TweetMVVM.Models
{
    public class Post 
    {
        public string Link { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublishRelativeDate
        {
            get
            {
                return TimeHelper.TimeAgo(PublishDate);
            }
        }
        public string ViewTweetLink
        {
            get
            {
                return "<a href=\"" + Link + "\">View on Twitter</a>";
            }
        }
        public string Author { get; set; }
        public string AuthorProfileImage { get; set; }
        public string AuthorScreenName { get; set; }
        public string AuthorScreenNameTwitter { get { return "@" + AuthorScreenName; } }
        public String Id { get; set; }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;

                description = description.Replace("<br>", "\n");
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        private bool showImage = false;
        public bool ShowImage
        {
            get { return showImage; }
            set { showImage = value; }
        }

        public string Image { get; set; }


        public List<ImageSize> ImageSizes { get; set; }


        public string ImageTwitter
        {
            get { return Image + ":small"; }
        }

        public int ImageTwitterWidth
        {
            get
            {
                if (ImageSizes == null) return 0;

                ImageSize size = ImageSizes.Where(x => x.Name == GlobalConstants.DefaultSocialImageSize).FirstOrDefault();
                return size?.Width ?? 0;
            }
        }

        public int ImageTwitterHeight
        {
            get
            {
                if (ImageSizes == null) return 0;

                ImageSize size = ImageSizes.Where(x => x.Name == GlobalConstants.DefaultSocialImageSize).FirstOrDefault();
                return size?.Height ?? 0;
            }
        }

    }
}
