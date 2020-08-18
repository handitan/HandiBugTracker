using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HandiBugTrackerWebClient.Library.Models
{
    public class CompBugOptionsViewModel
    {
        public List<BugPriorityViewModel> BugPriorityList { get; set; }

        //TODO??? Where the heck is bug priority in CompBug
        public IEnumerable<SelectListItem> BugPrioritySelectList
        {
            get
            {
                return BugPriorityList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }
        public List<BugSeverityViewModel> BugSeverityList { get; set; }
        public List<BugStatusViewModel> BugStatusList { get; set; }
        public IEnumerable<SelectListItem> BugStatusSelectList
        {
            get
            {
                return BugStatusList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }
        public List<BugStatusSubStateViewModel> BugStatusSubStateList { get; set; }
        public List<BugTypeViewModel> BugTypeList { get; set; }
        public List<ProductViewModel> ProductList { get; set; }
        public List<ProductHardwareViewModel> ProductHardwareList { get; set; }
        public List<ProductOSViewModel> ProductOSList { get; set; }
        public List<ComponentViewModel> ComponentList { get; set; }
        public List<ProductVersionViewModel> ProductVersionList { get; set; }
    }
}
