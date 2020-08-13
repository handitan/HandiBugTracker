using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class ProductData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ProductData(){}
        public ProductData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<ProductModel>> GetProductOSes()
        {
            var result = await _sqlDataAccess.LoadDataAsync<ProductModel, dynamic>(DataAccessConstant.SP_Product_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
