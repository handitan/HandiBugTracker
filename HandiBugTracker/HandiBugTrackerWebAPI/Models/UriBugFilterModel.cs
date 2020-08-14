using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandiBugTrackerWebAPI.Models
{
    public class UriBugFilterModel
    {
        public int BugId { get; set; } = -1;
        public string AssigneeId { get; set; } = null;
    }
}