using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace HandiBugTrackerDataManager.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        string GetConnectionString(string pName);
        Task<List<T>> LoadDataAsync<T, U>(string pStoredProcedure, U pParams, string pConnStringName);
        Task SaveDataAsync<T>(string pStoredProcedure, T pParams, string pConnStringName);
    }
}