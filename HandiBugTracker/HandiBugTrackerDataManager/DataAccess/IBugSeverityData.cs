using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public interface IBugSeverityData
    {
        Task<IEnumerable<BugSeverityModel>> GetBugSeverities();
    }
}