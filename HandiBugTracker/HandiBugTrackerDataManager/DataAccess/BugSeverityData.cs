using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class BugSeverityData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public BugSeverityData(){}
        public BugSeverityData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugSeverityModel>> GetProductOSes()
        {
            var result = await _sqlDataAccess.LoadDataAsync<BugSeverityModel, dynamic>(DataAccessConstant.SP_BugSeverity_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
