using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandiBugTrackerDataManager.Models
{
    public class ComponentBugModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CompId { get; set; }
        public string CompName { get; set; }
        
        public string ReporterId { get; set; }
        public string ReporterName { get; set; }
        public string AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public string QAId { get; set; }
        public string QAName { get; set; }

        public int ProdVerId { get; set; }
        public int BugPriorityId { get; set; }
        public int BugSeverityId { get; set; }
        public int ProductHwId { get; set; }
        public int ProductOSId { get; set; }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int SubStateId { get; set; }
        public string SubStateName { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
