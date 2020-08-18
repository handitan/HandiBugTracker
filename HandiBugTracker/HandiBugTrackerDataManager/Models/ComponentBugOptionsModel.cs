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
        public List<BugStatusSubStateModel> BugStatusSubStateList { get; set; }
        public List<BugTypeModel> BugTypeList { get; set; }
        public List<ProductModel> ProductList { get; set; }
        public List<ProductHardwareModel> ProductHardwareList { get; set; }
        public List<ProductOSModel> ProductOSList { get; set; }
        public List<ComponentModel> ComponentList { get; set; }
        public List<ProductVersionModel> ProductVersionList { get; set; }
    }
}
