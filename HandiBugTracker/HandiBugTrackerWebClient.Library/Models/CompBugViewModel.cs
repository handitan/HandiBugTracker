using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandiBugTrackerWebClient.Library.Models
{
    public class CompBugViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CompId { get; set; }
        public string CompName { get; set; }
        public string AssigneeName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int SubStateId { get; set; }
        public string SubStateName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public IList<BugCommentViewModel> BugComments { get; set; }

        //client side
        public string ClientNewComment { get; set; }
    }
}
