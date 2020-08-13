using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class BugPriorityData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public BugPriorityData(){}
        public BugPriorityData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugPriorityModel>> GetProductOSes()
        {
            var result = await _sqlDataAccess.LoadDataAsync<BugPriorityModel, dynamic>(DataAccessConstant.SP_BugSeverity_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
