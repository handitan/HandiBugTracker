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
        public IEnumerable<SelectListItem> BugSeveritySelectList
        {
            get
            {
                return BugSeverityList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }

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
        public IEnumerable<SelectListItem> BugStatusSubStateSelectList
        {
            get
            {
                return BugStatusSubStateList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }

        public List<BugTypeViewModel> BugTypeList { get; set; }
        public IEnumerable<SelectListItem> BugTypeSelectList
        {
            get
            {
                return BugTypeList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }

        public List<ProductViewModel> ProductList { get; set; }
        public IEnumerable<SelectListItem> ProductSelectList
        {
            get
            {
                return ProductList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }

        public List<ProductHardwareViewModel> ProductHardwareList { get; set; }
        public IEnumerable<SelectListItem> ProductHwSelectList
        {
            get
            {
                return ProductHardwareList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }

        public List<ProductOSViewModel> ProductOSList { get; set; }
        public IEnumerable<SelectListItem> ProductOSSelectList
        {
            get
            {
                return ProductOSList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }

        public List<ComponentViewModel> ComponentList { get; set; }
        public IEnumerable<SelectListItem> ComponentSelectList
        {
            get
            {
                return ComponentList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }

        public List<ProductVersionViewModel> ProductVersionList { get; set; }
        public IEnumerable<SelectListItem> ProductVersionSelectList
        {
            get
            {
                return ProductVersionList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            }
        }
    }
}
