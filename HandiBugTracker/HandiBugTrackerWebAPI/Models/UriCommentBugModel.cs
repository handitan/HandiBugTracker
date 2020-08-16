using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandiBugTrackerWebAPI.Models
{
    public class UriCommentBugModel
    {
        public int BugId { get; set; }
        public string Description { get; set; }
        public string ReporterId { get; set; }
    }
}