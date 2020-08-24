using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandiBugTrackerWebClient.Library.Models
{
    public class CompBugViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Summary")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Display(Name = "Component")]
        public int CompId { get; set; }
        public string CompName { get; set; }

        public string ReporterId { get; set; }
        public string ReporterName { get; set; }
        public string AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public string QAId { get; set; }
        public string QAName { get; set; }

        [Display(Name="Version")]
        public int ProdVerId { get; set; }
        [Display(Name = "Priority")]
        public int BugPriorityId { get; set; }
        [Display(Name = "Severity")]
        public int BugSeverityId { get; set; }
        [Display(Name = "Hardware")]
        public int ProductHwId { get; set; }
        [Display(Name = "OS")]
        public int ProductOSId { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        [Display(Name = "Resolution")]
        public int SubStateId { get; set; }
        public string SubStateName { get; set; }
        public DateTime LastModifiedDate { get; set; }

        //client side
        public IList<BugCommentViewModel> BugComments { get; set; } = new List<BugCommentViewModel>();
        public string ClientNewComment { get; set; }
    }
}
