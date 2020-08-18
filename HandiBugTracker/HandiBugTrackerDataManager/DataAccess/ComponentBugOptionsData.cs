using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HandiBugTrackerDataManager.Internal.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerDataManager.DataAccess
{
    public class ComponentBugOptionsData : IComponentBugOptionsData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public ComponentBugOptionsData() { }
        public ComponentBugOptionsData(ISqlDataAccess pSQLDataAccess)
        {
            this._sqlDataAccess = pSQLDataAccess;
        }

        public async Task<ComponentBugOptionsModel> GetComponentBugOptions()
        {
            ComponentBugOptionsModel optionsList = new ComponentBugOptionsModel();

            try
            {
                string connString = _sqlDataAccess.GetConnectionString(DataAccessConstant.HandiBugTrackerConn);
                using (IDbConnection conn = new SqlConnection(connString))
                {
                    var result = await conn.QueryMultipleAsync(DataAccessConstant.SP_ComponentBug_GetAllOptions);

                    optionsList.BugPriorityList = result.Read<BugPriorityModel>().ToList();
                    optionsList.BugSeverityList = result.Read<BugSeverityModel>().ToList();
                    optionsList.BugStatusList = result.Read<BugStatusModel>().ToList();
                    optionsList.BugStatusSubStateList = result.Read<BugStatusSubStateModel>().ToList();
                    optionsList.BugTypeList = result.Read<BugTypeModel>().ToList();
                    optionsList.ProductList = result.Read<ProductModel>().ToList();
                    optionsList.ProductHardwareList = result.Read<ProductHardwareModel>().ToList();
                    optionsList.ProductOSList = result.Read<ProductOSModel>().ToList();
                    optionsList.ComponentList = result.Read<ComponentModel>().ToList();
                    optionsList.ProductVersionList = result.Read<ProductVersionModel>().ToList();

                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL Invalid operation exception", GetType().FullName), ex);
            }

            return optionsList;
        }
    }
}
