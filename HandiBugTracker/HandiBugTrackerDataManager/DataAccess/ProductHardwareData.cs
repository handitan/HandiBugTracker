using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class ProductHardwareData : IProductHardwareData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ProductHardwareData() { }
        public ProductHardwareData(ISqlDataAccess pSQLDataAccess)
        {
            _sqlDataAccess = pSQLDataAccess;
        }

        public async Task<IEnumerable<ProductHardwareModel>> GetProductHardwares()
        {
            var result = await _sqlDataAccess.LoadDataAsync<ProductHardwareModel, dynamic>(DataAccessConstant.SP_ProductHardware_GetAll, new { }, DataAccessConstant.HandiBugTrackerConn);
            return result;
        }
    }
}
