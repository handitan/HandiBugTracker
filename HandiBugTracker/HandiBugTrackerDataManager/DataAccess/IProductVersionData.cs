using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public interface IProductVersionData
    {
        Task<IEnumerable<ProductVersionModel>> GetProductVersionsByProduct(int pProductId);
    }
}