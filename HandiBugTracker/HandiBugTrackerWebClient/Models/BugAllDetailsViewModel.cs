using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Models
{
    public class BugAllDetailsViewModel
    {
        public CompBugViewModel CompBug { get; set; }
        public CompBugOptionsViewModel CompBugOptions { get; set; }
    }
}