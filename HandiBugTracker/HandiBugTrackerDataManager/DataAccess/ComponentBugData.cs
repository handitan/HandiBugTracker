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
            var result = await _sqlDataAccess.LoadDataAsync<ComponentBugModel, dynamic>(DataAccessConstant.SP_ComponentBug_GetFilterBy, 
               new { Id = pBugId, AssigneeId = pAssigneeId},
               DataAccessConstant.HandiBugTrackerConn);
            return result;
        }

        public async Task EditComponentBug(ComponentBugParamModel pCompBugParamModel)
        {
            await _sqlDataAccess.SaveDataAsync<ComponentBugParamModel>(DataAccessConstant.SP_ComponentBug_Edit,
               pCompBugParamModel,
               DataAccessConstant.HandiBugTrackerConn);
        }
        public async Task<IEnumerable<int>> CreateComponentBug(ComponentBugPostParamModel pCompBugParamModel)
        {
            var result = await _sqlDataAccess.LoadDataAsync<int, ComponentBugPostParamModel>(DataAccessConstant.SP_ComponentBug_Create,
               pCompBugParamModel,
               DataAccessConstant.HandiBugTrackerConn);
            return result;
        }

        public async Task DeleteComponentBug(int id)
        {
            await _sqlDataAccess.SaveDataAsync<dynamic>(DataAccessConstant.SP_ComponentBug_Delete,
               new { Id = id },
               DataAccessConstant.HandiBugTrackerConn);
        }
    }
}
