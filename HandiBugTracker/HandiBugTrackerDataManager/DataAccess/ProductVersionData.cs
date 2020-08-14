using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class ProductVersionData : IProductVersionData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ProductVersionData() { }
        public ProductVersionData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<ProductVersionModel>> GetProductVersionsByProduct(int pProductId)
        {
            var result = await _sqlDataAccess.LoadDataAsync<ProductVersionModel, dynamic>(DataAccessConstant.SP_ProductVersion_GetByProduct, new { ProductId = pProductId }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
