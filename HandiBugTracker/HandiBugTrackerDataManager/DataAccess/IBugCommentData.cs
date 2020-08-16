using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public interface IBugCommentData
    {
        Task<IEnumerable<BugCommentModel>> GetBugCommentByBugId(int pBugId);
        Task CreateBugCommentBy(int pBugId, string pDescription, string pReporterId);
        Task EditBugCommentBy(int pBugId, string pDescription, string pReporterId);
    }
}