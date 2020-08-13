using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class ProductOSData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ProductOSData(){}
        public ProductOSData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<ProductOSModel>> GetProductOSes()
        {
            var result = await _sqlDataAccess.LoadDataAsync<ProductOSModel, dynamic>(DataAccessConstant.SP_ProductOS_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
