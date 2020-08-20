using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public interface IBugDetailEndpoint
    {
        Task<IList<CompBugViewModel>> GetByBugId(int pId);
        Task Edit(CompBugViewModel pComBugViewModel);
        Task Create(CompBugViewModel pComBugViewModel);
    }
}