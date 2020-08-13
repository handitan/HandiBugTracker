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
        public string TypeName { get; set; }
        public string ProductName { get; set; }
        public string CompName { get; set; }
        public string FullName { get; set; }
        public string StatusName { get; set; }
        public string SubStateName { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
