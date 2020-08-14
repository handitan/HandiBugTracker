using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class ComponentBugData : IComponentBugData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ComponentBugData() { }
        public ComponentBugData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<ComponentBugModel>> GetComponentBugFilterBy(int pBugId = -1, string pAssigneeId = null)
        {
            var result = await _sqlDataAccess.LoadDataAsync<ComponentBugModel, dynamic>(DataAccessConstant.SP_ComponentBug_GetFilterBy, new { AssigneeId = pBugId, Id = pBugId }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
