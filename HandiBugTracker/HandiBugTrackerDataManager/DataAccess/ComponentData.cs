using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class ComponentData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ComponentData(){}
        public ComponentData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<BugCommentModel>> GetComponentByProductId(int pProductId)
        {

            var result = await _sqlDataAccess.LoadDataAsync<BugCommentModel, dynamic>(DataAccessConstant.SP_Component_GetByProduct, new { ProductId = pProductId }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
