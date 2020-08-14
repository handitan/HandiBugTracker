using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class BugStatusData : IBugStatusData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public BugStatusData() { }
        public BugStatusData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugStatusModel>> GetBugStatuses()
        {
            var result = await _sqlDataAccess.LoadDataAsync<BugStatusModel, dynamic>(DataAccessConstant.SP_BugStatus_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
