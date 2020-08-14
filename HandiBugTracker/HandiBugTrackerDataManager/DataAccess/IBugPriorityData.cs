using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public interface IBugPriorityData
    {
        Task<IEnumerable<BugPriorityModel>> GetBugPriorities();
    }
}