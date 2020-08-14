using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public interface IComponentData
    {
        Task<IEnumerable<ComponentModel>> GetComponentByProductId(int pProductId);
    }
}