﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TweetMVVM.Models
{
    public class BreachedAccount
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string BreachDate { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int PwnCount { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public IList<string> DataClasses { get; set; }
        public bool IsVerified { get; set; }
        public bool IsFabricated { get; set; }
        public bool IsSensitive { get; set; }
        public bool IsRetired { get; set; }
        public bool IsSpamList { get; set; }
        public string EmailAddress { get; set; }
    }
}
