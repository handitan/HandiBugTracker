using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandiBugTrackerDataManager.Models
{
    public class ComponentBugOptionsModel
    {
        public List<BugPriorityModel> BugPriorityList { get; set; }
        public List<BugSeverityModel> BugSeverityList { get; set; }
        public List<BugStatusModel> BugStatusList { get; set; }
    }
}
