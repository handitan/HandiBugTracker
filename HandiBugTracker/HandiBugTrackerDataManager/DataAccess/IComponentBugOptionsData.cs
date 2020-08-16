using System.Threading.Tasks;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public interface IComponentBugOptionsData
    {
        Task<ComponentBugOptionsModel> GetComponentBugOptions();
    }
}