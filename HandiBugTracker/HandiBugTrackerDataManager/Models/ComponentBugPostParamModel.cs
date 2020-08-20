using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace HandiBugTrackerDataManager.Models
{
    public class ComponentBugPostParamModel
    {
        public string Name { get; set; }

        public string ReporterId { get; set; }
        public string AssigneeId { get; set; }
        public string QAContactId { get; set; }

        public int ProductId { get; set; }
        public int ProductVersionId { get; set; }
        public int BugStatusId { get; set; }

        public int BugStatusSubStateId { get; set; }
        public int BugPriorityId { get; set; }
        public int BugSeverityId { get; set; }

        public int BugTypeId { get; set; }
        public int ProductHardwareId { get; set; }
        public int ProductOSId { get; set; }
        public int ComponentId { get; set; }
    }
}