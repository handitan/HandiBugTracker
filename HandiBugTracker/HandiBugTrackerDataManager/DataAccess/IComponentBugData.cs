using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public interface IComponentBugData
    {
        Task<IEnumerable<ComponentBugModel>> GetComponentBugFilterBy(int pBugId = -1, string pAssigneeId = null);
        Task EditComponentBug(ComponentBugParamModel pCompBugParamModel);
        Task<IEnumerable<int>> CreateComponentBug(ComponentBugPostParamModel pCompBugParamModel);



    }
}