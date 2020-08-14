using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class BugTypeData : IBugTypeData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public BugTypeData() { }
        public BugTypeData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugTypeModel>> GetBugTypes()
        {
            var result = await _sqlDataAccess.LoadDataAsync<BugTypeModel, dynamic>(DataAccessConstant.SP_BugType_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
